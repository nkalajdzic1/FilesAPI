using AutoMapper;
using FilesAPI.Dtos;
using FilesAPI.Models;
using FilesAPI.Responses;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FilesAPI.Data
{
    public class MongoFileService
    {
        private readonly IMongoCollection<FileModel> _fileCollection;
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        public readonly IMapper _mapper;

        public MongoFileService(IOptions<MongoSettings> options, IMapper mapper)
        {
            _mapper = mapper;
            _mongoClient = new MongoClient(options.Value.Connection);
            _mongoDatabase = _mongoClient.GetDatabase(options.Value.Database);
            _fileCollection = _mongoDatabase.GetCollection<FileModel>(options.Value.Collection);
        }

        /// <summary>
        /// gets files from the mongo database
        /// </summary>
        /// <returns></returns>
        public async Task<List<FileModelDto>> Get()
        {
           return await _fileCollection.Find(_ => true).Project(x => _mapper.Map<FileModelDto>(x)).ToListAsync();
        }

        /// <summary>
        ///    file upload function to the mongo database
        /// </summary>
        /// <param name="fileModel">file uploaded from form</param>
        /// <returns></returns>
        public async Task<Response<UploadedFileDto>> Create(IFormFile file)
        {
            using(var target = new MemoryStream())
            {
                file.CopyTo(target);

                var newFile = new FileModel() 
                { 
                    Name = file.FileName,
                    Size = file.Length,
                    MimeType = file.ContentType,
                    Content = target.ToArray(),  
                };

                await _fileCollection.InsertOneAsync(newFile);
            }
           
            return new Response<UploadedFileDto>() 
                { 
                    IsSuccess = true, 
                    Message = $"Successfully uploaded file {file.FileName}",
                    Data = new UploadedFileDto()
                    {
                        FileName = file.FileName,
                        MimeType = file.ContentType,
                    }
                };
        }
    }
}
