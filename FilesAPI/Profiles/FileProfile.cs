using AutoMapper;
using FilesAPI.Dtos;
using FilesAPI.Models;

namespace FilesAPI.Profiles
{
    public class FileProfile: Profile
    {
        public FileProfile()
        {
            CreateMap<FileModelDto, FileModel>();
            CreateMap<FileModel, FileModelDto>();
        }
    }
}
