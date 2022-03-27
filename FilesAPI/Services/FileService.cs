using FilesAPI.Data;
using FilesAPI.Dtos;
using FilesAPI.Interfaces;
using FilesAPI.Models;
using FilesAPI.Responses;

namespace FilesAPI.Services
{
    public class FileService: IFileService
    {
        private readonly MongoFileService _mongoFileService;

        public FileService(MongoFileService mongoFileService)
        {
           _mongoFileService = mongoFileService;
        }

        async public Task<List<FileModelDto>> Get() => await _mongoFileService.Get();

        public async Task<Response<UploadedFileDto>> Upload(IFormFile file) => await _mongoFileService.Create(file);
    }
}
