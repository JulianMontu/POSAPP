using AutoMapper;
using POS.Aplication.Commons.Bases;
using POS.Aplication.DTOS.Request;
using POS.Aplication.DTOS.Response;
using POS.Aplication.Interfaces;
using POS.Aplication.Validators.Category;
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
            return response

        }
        public Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
