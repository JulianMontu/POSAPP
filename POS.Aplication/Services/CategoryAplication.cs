using AutoMapper;
using POS.Aplication.Commons.Bases;
using POS.Aplication.DTOS.Request;
using POS.Aplication.DTOS.Response;
using POS.Aplication.Interfaces;
using POS.Aplication.Validators.Category;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases;
using POS.Infrastructure.Persistence.Interfaces;
using POS.Utilities.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Services
{
    public class CategoryAplication : ICategoryAplication
    {
        private readonly IUnitsOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _validatorRules;

        public CategoryAplication(IUnitsOfWork unitOfWork, IMapper mapper, CategoryValidator validatorRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorRules = validatorRules;
        }
        public async Task<BaseResponse<BaseEntityResponse<CategoryResponseDTO>>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryResponseDTO>>();
            var categories = await _unitOfWork.Category.ListCategories(filters);
            if(categories is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<BaseEntityResponse<CategoryResponseDTO>>(categories);
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message= ReplyMessages.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDTO>>();
            var categories = await _unitOfWork.Category.ListSelectCategories();

            if (categories is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDTO>>(categories);
                response.Message = ReplyMessages.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_QUERY_EMPTY;
            }
            return response;

        }
        public async Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId)
        {
            var response = new BaseResponse<CategoryResponseDTO>();
            var category = await _unitOfWork.Category.CategoryById(categoryId);

            if (category is not null) 
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<CategoryResponseDTO>(category);
                response.Message = ReplyMessages.MESSAGE_QUERY;

            }
            else 
            { 
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validatorRules.ValidateAsync(requestDTO);

            if(!validationResult.IsValid) 
            {
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_VALIDATE; 
                response.Errors = validationResult.Errors;
                return response;
            }

            var category = _mapper.Map<Category>(requestDTO);
            response.Data = await _unitOfWork.Category.RegisterCategory(category);

            if(response.Data) 
            {
                response.IsSucces = true;
                response.Message = ReplyMessages.MESSAGE_SAVE;
            }
            else
            { 
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_FAILED;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await CategoryById(categoryId);

            if (categoryEdit.Data is null)
            {
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_QUERY_EMPTY;
            }

            var category = _mapper.Map<Category>(requestDTO);
            category.CategoryId = categoryId;
            response.Data = await _unitOfWork.Category.EditCategory(category);

            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = ReplyMessages.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_FAILED;
            }
            return response;
        }
        public async Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            var response = new BaseResponse<bool>();
            var category = await CategoryById(categoryId);

            if (category.Data is null )
            {
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWork.Category.DeleteCategory(categoryId);

            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = ReplyMessages.MESSAGE_DELETE;
            }
            else 
            {
                response.IsSucces = false;
                response.Message = ReplyMessages.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
