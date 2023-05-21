using POS.Aplication.Commons.Bases;
using POS.Aplication.DTOS.Request;
using POS.Aplication.DTOS.Response;
using POS.Infrastructure.Commons.Bases;

namespace POS.Aplication.Interfaces
{
    public interface ICategoryAplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDTO>>> ListCategories(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditCategory(int categoryId,CategoryRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveCategory(int categoryId);
    }
}
