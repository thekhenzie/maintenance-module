using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.OrderManagement.Mitigation.ChildMitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderWildfireAssessmentChildMitigationRequirementsRepository : RepositoryBase<InspectionOrderWildfireAssessmentChildMitigationRequirements>,
        IInspectionOrderWildfireAssessmentChildMitigationRequirementsRepository
    {
        private readonly IRivingtonContext context;
        private readonly IImageService _imageService;
        private readonly IImageRepository _imageRepository;

        public InspectionOrderWildfireAssessmentChildMitigationRequirementsRepository(
            IRivingtonContext context,
            IImageService imageService,
            IImageRepository imageRepository) : base(context)
        {
            this.context = context;
            this._imageService = imageService;
            this._imageRepository = imageRepository;
        }

        public RetrieveResult<InspectionOrderWildfireAssessmentChildMitigationRequirements> RetrieveView(DataSourceRequest request, Guid mitigationRequirementsId)
        {
            var dbSet = context.Set<InspectionOrderWildfireAssessmentChildMitigationRequirements>()
                .Include(a => a.Image)
                .Include(a => a.User)
                .Where(a => a.IoWaParentMitigationRequirementsId == mitigationRequirementsId)
                .OrderBy(a => a.Image.CreatedAt);
            return Retrieve(dbSet, request);
        }

        public Image InsertOrUpdateWildfireAssessmentChildMitigationRequirement(InspectionOrder ioFromClient)
        {
            var parentMitigationRequirement = ioFromClient.WildfireAssessment.Mitigation.Requirements.First();

            var existingIoWaParentMitigationRequirement = Context.Set<InspectionOrderWildfireAssessmentMitigationRequirements>()
                .Include(x => x.ChildMitigation)
                .ThenInclude(x => x.Image)
                .SingleOrDefault(x => x.Id.Equals(parentMitigationRequirement.Id));

            if (existingIoWaParentMitigationRequirement == null)
                throw new Exception("Parent Mitigation not found.");

            var mrFromClient = parentMitigationRequirement.ChildMitigation.First();
            mrFromClient.IoWaParentMitigationRequirementsId = parentMitigationRequirement.Id;

            var childMitigationDbSet = context.Set<InspectionOrderWildfireAssessmentChildMitigationRequirements>();

            var imageFromClient = mrFromClient.Image;

            var isAdd = (imageFromClient.Id == Guid.Empty);
            var newId = Guid.NewGuid();

            if (isAdd)
            {
                if(mrFromClient.Image.File != null)
                {
                    imageFromClient.Id = newId;
                    _imageService.UpdateImageFile(imageFromClient, newId);

                    mrFromClient.Image = imageFromClient;
                }
                
                childMitigationDbSet.Add(mrFromClient);

                context.SaveChanges();

                return mrFromClient.Image;
            }
            else
            {
                var existingPm = childMitigationDbSet.SingleOrDefault(
                    w => w.IoWaParentMitigationRequirementsId == mrFromClient.IoWaParentMitigationRequirementsId &&
                         w.ImageId == imageFromClient.Id);

                if (existingPm == null)
                    throw new Exception("Image not found.");

                context.Entry(existingPm).CurrentValues.SetValues(mrFromClient);

                // this means that the image file from the client has changed
                if (imageFromClient.File != null)
                {
                    _imageService.UpdateImageFile(imageFromClient, newId);

                    var existingImage = _imageRepository.Retrieve(existingPm.ImageId);

                    context.Entry(existingImage).CurrentValues.SetValues(imageFromClient);

                    try
                    {
                        context.SaveChanges();

                        _imageService.DeleteImageFileInDisk(existingPm.Image.FilePath);
                        _imageService.DeleteImageFileInDisk(existingPm.Image.ThumbnailPath);

                        return existingPm.Image;
                    }
                    catch (Exception e)
                    {


                    }
                }
                else
                {
                    context.SaveChanges();
                }


                return imageFromClient;
            }
        }

        public int childMitigationCount(Guid parentId)
        {
            return context.Set<InspectionOrderWildfireAssessmentChildMitigationRequirements>()
                    .Count(m => m.IoWaParentMitigationRequirementsId == parentId);

        }
    }
}
