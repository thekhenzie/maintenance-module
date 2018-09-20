using ART.DynamicLinq;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using Rivington.IG.Domain.OrderManagement.InspectionOrderNonWildfireAssessment.Mitigation.ChildMitigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository: RepositoryBase<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations>,
        IInspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository
    {
        private readonly IRivingtonContext context;
        private readonly IImageService _imageService;
        private readonly IImageRepository _imageRepository;

        public InspectionOrderNonWildfireAssessmentChildMitigationRecommendationsRepository(
            IRivingtonContext context,
            IImageService imageService,
            IImageRepository imageRepository) : base(context)
        {
            this.context = context;
            this._imageService = imageService;
            this._imageRepository = imageRepository;
        }

        public RetrieveResult<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations> RetrieveView(DataSourceRequest request, Guid mitigationRecommendationsId)
        {
            var dbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations>()
                .Include(a => a.Image)
                .Include(a => a.User)
                .Where(a => a.IoNWaParentMitigationRecommendationsId == mitigationRecommendationsId)
                .OrderBy(a => a.Image.CreatedAt);
            return Retrieve(dbSet, request);
        }

        public Image InsertOrUpdateNonWildfireAssessmentChildMitigationRecommendation(InspectionOrder ioFromClient)
        {
            var parentMitigationRecommendation = ioFromClient.Property.NonWildfireAssessment.Mitigation.Recommendations.First();

            var existingIoNWaParentMitigationRecommendation = Context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>()
                .Include(x => x.ChildMitigation)
                .ThenInclude(x => x.Image)
                .SingleOrDefault(x => x.Id.Equals(parentMitigationRecommendation.Id));

            if (existingIoNWaParentMitigationRecommendation == null)
                throw new Exception("Inspection Order not found.");

            var mrFromClient = parentMitigationRecommendation.ChildMitigation.First();
            mrFromClient.IoNWaParentMitigationRecommendationsId = parentMitigationRecommendation.Id;

            var childMitigationDbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations>();

            var imageFromClient = mrFromClient.Image;

            var isAdd = (imageFromClient.Id == Guid.Empty);
            var newId = Guid.NewGuid();

            if (isAdd)
            {
                if (mrFromClient.Image.File != null)
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
                    w => w.IoNWaParentMitigationRecommendationsId == mrFromClient.IoNWaParentMitigationRecommendationsId &&
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
            return context.Set<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations>()
                    .Count(m => m.IoNWaParentMitigationRecommendationsId == parentId);
        }
    }
}
