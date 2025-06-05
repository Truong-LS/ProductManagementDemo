using BusinessObjects;
using Repositories_Repositories;

using System.Collections.Generic;


namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository iCategoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            iCategoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            return iCategoryRepository.GetCategories();
        }
    }
}
