using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Handlers;
using API.NaturalEventTracker.Domain.Interfaces;
using API.NaturalEventTracker.Unit.Test.Helpers;
using API.NaturalEventTracker.Unit.Test.Mocks;
using Moq;
using System.Threading;
using Xunit;

namespace API.NaturalEventTracker.Unit.Test
{
    public class CategoryTests
    {
        [Fact(DisplayName = "Return A List Of Categories")]
        [Trait("NaturalEventTracker", "Handler: ListCategoryCommandHandler")]
        public async void ListCategoryCommandHandler_ReturnAllCategories_MustReturnNotNull()
        {
            var categoryFaker = new CategoryFaker();
            var categoryRepository = new Mock<ICategoryRepository>();

            categoryRepository.Setup(r => r.GetAll())
                .Returns(categoryFaker.GetAllMock());

            var listCategoryCommandHandler = new ListCategoryCommandHandler(categoryRepository.Object, AutoMapperSingleton.Mapper);

            // Act
            var tariffs = await listCategoryCommandHandler.Handle(
                new ListCategoryCommand() { }, new CancellationToken());

            // Assert
            Assert.NotNull(tariffs);
        }

    }
}
