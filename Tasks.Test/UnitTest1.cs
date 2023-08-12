using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Context;
using TaskApi.Controllers;
using TaskApi.Models;

namespace Tasks.Test
{
    public class TodosControllerTests
    {

        [Fact]
        public async Task CreateTodo_ReturnsCreatedAtAction()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DataContext(dbContextOptions))
            {
                var controller = new TodosController(context);

                var newTodo = new Todo { Title = "New Todo" };

                // Act
                var result = await controller.CreateTodo(newTodo);

                // Assert
                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
                Assert.Equal(nameof(controller.GetTodoById), createdAtActionResult.ActionName);
            }
        }

        [Fact]
        public async Task UpdateTodo_WithValidId_ReturnsNoContentResult()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DataContext(dbContextOptions))
            {
                var controller = new TodosController(context);

                var existingTodo = new Todo { Id = 12, Title = "Existing Todo" };
                context.Todos.Add(existingTodo);
                context.SaveChanges();

                var updatedTodo = new Todo { Id = existingTodo.Id, Title = "Updated Todo" };

                // Act
                var result = await controller.UpdateTodo(existingTodo.Id, updatedTodo);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }

        [Fact]
        public async Task DeleteTodo_WithValidId_ReturnsNoContentResult()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new DataContext(dbContextOptions))
            {
                var controller = new TodosController(context);

                var existingTodo = new Todo { Id = 789, Title = "Existing Todo" };
                context.Todos.Add(existingTodo);
                context.SaveChanges();

                // Act
                var result = await controller.DeleteTodo(existingTodo.Id);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }
    }
}
