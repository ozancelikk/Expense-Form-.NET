using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.DTOs;

namespace Entities.Profiles.AutoMapperProfiles
{
    public class EntitiesAutoMapperProfile : Profile
    {
        public EntitiesAutoMapperProfile()
        {
            CreateMap<CustomerInformationDto, CustomerInformation>();
            CreateMap<TimeStampConfigDto, TimeStampConfig>();
            CreateMap<LicenseConfigDto, LicenseConfig>();
            CreateMap<RabbitMQConnectionSettingDto, RabbitMQConnectionSetting>();
            CreateMap<MailConfigDto, MailConfig>();
            CreateMap<ReportDto, ScheduledReport>();
            CreateMap<ArchiveConfigurationDto, ArchiveConfiguration>();
            CreateMap<VouncherDto, Vouncher>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<ReceiptDto,Receipt>();
            CreateMap<ExpenceDto, Expence>();
            CreateMap<ExpenceDetailDto, Expence>();
            CreateMap<ReportVoucherDto, ReportVoucher>();
            CreateMap<UploadFileDto, UploadFile>();
            CreateMap<PaymentDto, Payment>();
            CreateMap<UploadReceiptImageDto, UploadReceiptImage>();


        }
    }
}
