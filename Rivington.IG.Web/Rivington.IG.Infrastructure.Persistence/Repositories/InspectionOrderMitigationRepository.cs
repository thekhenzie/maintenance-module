using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.OrderManagement;
using Microsoft.EntityFrameworkCore;
using Rivington.IG.Domain.CustomCodes;
using Rivington.IG.Domain.Models.Views;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class InspectionOrderMitigationRepository : RepositoryBase<InspectionOrder>, IInspectionOrderMitigationRepository
    {
        private readonly IRivingtonContext context;
        private readonly IImageService _imageService;
        private readonly IImageRepository _imageRepository;

        public InspectionOrderMitigationRepository(
            IRivingtonContext context,
            IImageService imageService,
            IImageRepository imageRepository) : base(context)
        {
            this.context = context;
            _imageService = imageService;
            _imageRepository = imageRepository;
        }
        

        public Image InsertOrUpdateWildfireAssessmentMitigationRequirement(InspectionOrder ioFromClient)
        {
            var existingIo = Context.Set<InspectionOrder>()
                .Include(x => x.WildfireAssessment)
                .ThenInclude(x => x.Mitigation)
                .ThenInclude(x => x.Requirements)
                .SingleOrDefault(x => x.Id.Equals(ioFromClient.Id));

            if (existingIo == null)
                throw new Exception("Inspection Order not found.");

            var wildfireAssessment = existingIo.WildfireAssessment;
            if (wildfireAssessment == null)
            {
                wildfireAssessment = new InspectionOrderWildfireAssessment { Id = ioFromClient.Id };
                context.Entry(wildfireAssessment).State = EntityState.Added;
            }

            var mitigation = wildfireAssessment.Mitigation;
            if (mitigation == null)
            {
                mitigation = new InspectionOrderWildfireAssessmentMitigation { Id = ioFromClient.Id };
                context.Entry(mitigation).State = EntityState.Added;
            }

            if (mitigation.Requirements == null)
            {
                mitigation.Requirements = new List<InspectionOrderWildfireAssessmentMitigationRequirements>();
            }

            var pmFromClient = ioFromClient.WildfireAssessment.Mitigation.Requirements.First();
            pmFromClient.InspectionOrderWildfireAssessmentMitigationId = mitigation.Id;

            var requirementsDbSet = context.Set<InspectionOrderWildfireAssessmentMitigationRequirements>();

            var imageFromClient = pmFromClient.Image;

            var isAdd = (imageFromClient.Id == Guid.Empty);
            var newId = Guid.NewGuid();

            if (isAdd)
            {
                imageFromClient.Id = newId;
                _imageService.UpdateImageFile(imageFromClient, newId);

                pmFromClient.Image = imageFromClient;
                requirementsDbSet.Add(pmFromClient);

                context.SaveChanges();

                return pmFromClient.Image;
            }
            else // update
            {
                var existingPm = requirementsDbSet.SingleOrDefault(
                    w => w.InspectionOrderWildfireAssessmentMitigationId == pmFromClient.InspectionOrderWildfireAssessmentMitigationId &&
                         w.ImageId == imageFromClient.Id);
                
                if(existingPm == null)
                    throw new Exception("Image not found.");

                context.Entry(existingPm).CurrentValues.SetValues(pmFromClient);

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
        

        public Image InsertOrUpdateWildfireAssessmentMitigationRecommendation(InspectionOrder ioFromClient)
        {
            var existingIo = Context.Set<InspectionOrder>()
                .Include(x => x.WildfireAssessment)
                .ThenInclude(x => x.Mitigation)
                .ThenInclude(x => x.Recommendations)
                .SingleOrDefault(x => x.Id.Equals(ioFromClient.Id));

            if (existingIo == null)
                throw new Exception("Inspection Order not found.");

            var wildfireAssessment = existingIo.WildfireAssessment;
            if (wildfireAssessment == null)
            {
                wildfireAssessment = new InspectionOrderWildfireAssessment { Id = ioFromClient.Id };
                context.Entry(wildfireAssessment).State = EntityState.Added;
            }

            var mitigation = wildfireAssessment.Mitigation;
            if (mitigation == null)
            {
                mitigation = new InspectionOrderWildfireAssessmentMitigation { Id = ioFromClient.Id };
                context.Entry(mitigation).State = EntityState.Added;
            }

            if (mitigation.Recommendations == null)
            {
                mitigation.Recommendations = new List<InspectionOrderWildfireAssessmentMitigationRecommendations>();
            }

            var pmFromClient = ioFromClient.WildfireAssessment.Mitigation.Recommendations.First();
            pmFromClient.InspectionOrderWildfireAssessmentMitigationId = mitigation.Id;

            var requirementsDbSet = context.Set<InspectionOrderWildfireAssessmentMitigationRecommendations>();

            var imageFromClient = pmFromClient.Image;

            var isAdd = (imageFromClient.Id == Guid.Empty);
            var newId = Guid.NewGuid();

            if (isAdd)
            {
                imageFromClient.Id = newId;
                _imageService.UpdateImageFile(imageFromClient, newId);

                pmFromClient.Image = imageFromClient;
                requirementsDbSet.Add(pmFromClient);

                context.SaveChanges();

                return pmFromClient.Image;
            }
            else // update
            {
                var existingPm = requirementsDbSet.SingleOrDefault(
                    w => w.InspectionOrderWildfireAssessmentMitigationId == pmFromClient.InspectionOrderWildfireAssessmentMitigationId &&
                         w.ImageId == imageFromClient.Id);
                
                if(existingPm == null)
                    throw new Exception("Image not found.");

                context.Entry(existingPm).CurrentValues.SetValues(pmFromClient);

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

        // Nonwildfire
        

        public Image InsertOrUpdateNonWildfireAssessmentMitigationRequirement(InspectionOrder ioFromClient)
        {
            var existingIo = Context.Set<InspectionOrder>()
                .Include(x => x.Property)
                .ThenInclude(x => x.NonWildfireAssessment)
                .ThenInclude(x => x.Mitigation)
                .ThenInclude(x => x.Requirements)
                .SingleOrDefault(x => x.Id.Equals(ioFromClient.Id));

            if (existingIo == null)
                throw new Exception("Inspection Order not found.");

            var property = existingIo.Property;
            if (property == null)
            {
                property = new InspectionOrderProperty { Id = ioFromClient.Id };
                context.Entry(property).State = EntityState.Added;
            }

            var nonWildfireAssessment = property.NonWildfireAssessment;
            if (nonWildfireAssessment == null)
            {
                nonWildfireAssessment = new InspectionOrderPropertyNonWildfireAssessment { Id = ioFromClient.Id };
                context.Entry(nonWildfireAssessment).State = EntityState.Added;
            }

            var mitigation = nonWildfireAssessment.Mitigation;
            if (mitigation == null)
            {
                mitigation = new InspectionOrderPropertyNonWildfireAssessmentMitigation { Id = ioFromClient.Id };
                context.Entry(mitigation).State = EntityState.Added;
            }

            if (mitigation.Requirements == null)
            {
                mitigation.Requirements = new List<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>();
            }

            var pmFromClient = ioFromClient.Property.NonWildfireAssessment.Mitigation.Requirements.First();
            pmFromClient.InspectionOrderPropertyNonWildfireAssessmentMitigationId = mitigation.Id;

            var requirementsDbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>();

            var imageFromClient = pmFromClient.Image;

            var isAdd = (imageFromClient.Id == Guid.Empty);
            var newId = Guid.NewGuid();

            if (isAdd)
            {
                imageFromClient.Id = newId;
                _imageService.UpdateImageFile(imageFromClient, newId);

                pmFromClient.Image = imageFromClient;
                requirementsDbSet.Add(pmFromClient);

                context.SaveChanges();

                return pmFromClient.Image;
            }
            else // update
            {
                var existingPm = requirementsDbSet.SingleOrDefault(
                    w => w.InspectionOrderPropertyNonWildfireAssessmentMitigationId == pmFromClient.InspectionOrderPropertyNonWildfireAssessmentMitigationId &&
                         w.ImageId == imageFromClient.Id);
                
                if(existingPm == null)
                    throw new Exception("Image not found.");

                context.Entry(existingPm).CurrentValues.SetValues(pmFromClient);

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
        

        public Image InsertOrUpdateNonWildfireAssessmentMitigationRecommendation(InspectionOrder ioFromClient)
        {
            var existingIo = Context.Set<InspectionOrder>()
                .Include(x => x.Property)
                .ThenInclude(x => x.NonWildfireAssessment)
                .ThenInclude(x => x.Mitigation)
                .ThenInclude(x => x.Recommendations)
                .SingleOrDefault(x => x.Id.Equals(ioFromClient.Id));

            if (existingIo == null)
                throw new Exception("Inspection Order not found.");

            var property = existingIo.Property;
            if (property == null)
            {
                property = new InspectionOrderProperty { Id = ioFromClient.Id };
                context.Entry(property).State = EntityState.Added;
            }

            var nonWildfireAssessment = property.NonWildfireAssessment;
            if (nonWildfireAssessment == null)
            {
                nonWildfireAssessment = new InspectionOrderPropertyNonWildfireAssessment { Id = ioFromClient.Id };
                context.Entry(nonWildfireAssessment).State = EntityState.Added;
            }

            var mitigation = nonWildfireAssessment.Mitigation;
            if (mitigation == null)
            {
                mitigation = new InspectionOrderPropertyNonWildfireAssessmentMitigation { Id = ioFromClient.Id };
                context.Entry(mitigation).State = EntityState.Added;
            }

            if (mitigation.Recommendations == null)
            {
                mitigation.Recommendations = new List<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>();
            }

            var pmFromClient = ioFromClient.Property.NonWildfireAssessment.Mitigation.Recommendations.First();
            pmFromClient.InspectionOrderPropertyNonWildfireId = mitigation.Id;

            var requirementsDbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>();

            var imageFromClient = pmFromClient.Image;

            var isAdd = (imageFromClient.Id == Guid.Empty);
            var newId = Guid.NewGuid();

            if (isAdd)
            {
                imageFromClient.Id = newId;
                _imageService.UpdateImageFile(imageFromClient, newId);

                pmFromClient.Image = imageFromClient;
                requirementsDbSet.Add(pmFromClient);

                context.SaveChanges();

                return pmFromClient.Image;
            }
            else // update
            {
                var existingPm = requirementsDbSet.SingleOrDefault(
                    w => w.InspectionOrderPropertyNonWildfireId == pmFromClient.InspectionOrderPropertyNonWildfireId &&
                         w.ImageId == imageFromClient.Id);
                
                if(existingPm == null)
                    throw new Exception("Image not found.");

                context.Entry(existingPm).CurrentValues.SetValues(pmFromClient);

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

        public int CountMitigationRequirements(Guid inspectionOrderId)
        {
            var ioNWaRequirementsDbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>();
            int countIoNWaRequirements = ioNWaRequirementsDbSet
                .Count(m => m.InspectionOrderPropertyNonWildfireAssessmentMitigationId == inspectionOrderId
                    && m.Status == false);

            var ioWaRequirementsDbSet = context.Set<InspectionOrderWildfireAssessmentMitigationRequirements>();
            int countIoWaRequirements = ioWaRequirementsDbSet
                .Count(m => m.InspectionOrderWildfireAssessmentMitigationId == inspectionOrderId
                    && m.Status == false);

            return countIoNWaRequirements + countIoWaRequirements;
        }

        public int CountAllMitigations(Guid inspectionOrderId)
        {
            var ioNWaRequirementsDbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>();
            int countIoNWaRequirements = ioNWaRequirementsDbSet
                .Count(m => m.InspectionOrderPropertyNonWildfireAssessmentMitigationId == inspectionOrderId
                    && m.Status == false);

            var ioNWaRecommendationsDbSet = context.Set<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>();
            int countIoNWaRecommendations = ioNWaRecommendationsDbSet
                .Count(m => m.InspectionOrderPropertyNonWildfireId == inspectionOrderId
                    && m.Status == false);

            var ioWaRequirementsDbSet = context.Set<InspectionOrderWildfireAssessmentMitigationRequirements>();
            int countIoWaRequirements = ioWaRequirementsDbSet
                .Count(m => m.InspectionOrderWildfireAssessmentMitigationId == inspectionOrderId
                    && m.Status == false);

            var ioWaRecommendationsDbSet = context.Set<InspectionOrderWildfireAssessmentMitigationRecommendations>();
            int countIoWaRecommendations = ioWaRecommendationsDbSet
                .Count(m => m.InspectionOrderWildfireAssessmentMitigationId == inspectionOrderId
                    && m.Status == false);

            return countIoNWaRequirements + countIoNWaRecommendations + countIoWaRequirements + countIoWaRecommendations;
        }
    }
}