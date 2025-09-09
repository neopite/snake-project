using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using FluentAssertions;
using FluentAssertions.Common;
using Moq;
using NUnit.Framework;

namespace Snake.Core.Tests
{
    public class GameLoopTest
    {
        private Fixture _f;
        
        public GameLoopTest()
        {
            _f = new Fixture();
            _f.Customize(new AutoMoqCustomization());
        }
        

        [Theory]
        [AutoMoqData]
        public void SnakeGrowth_WhenEatsFood_LengthIncreases(
            [Frozen] Mock<IFoodService> foodService,
            [Frozen] Mock<ISnakeModel> snakeModel,
            GameLoopController gameLoopController
        )
        {
            // Arrange

            var position = _f.Create<Vector2Int>();
            var points = _f.Create<int>();
            
            var foodModel = new FoodModel(points, position);

            snakeModel.Setup(x => x.Head).Returns(position);
            foodService
                .Setup(x => x.CanCollectFood(position, out foodModel))
                .Returns(true);

            // Act
            gameLoopController.Step();

            // Assert
            snakeModel.Verify(x => x.Grow(), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        public void CollisionDetection_WhenSnakeCollides_GameOverTriggered(
            [Frozen] Mock<ISnakeCollisionService> collisionService,
            GameLoopController gameLoopController)
        {
            // Arrange
            collisionService.Setup(x => x.IsCollided()).Returns(true);

            ControllerState? newState = null;
            gameLoopController.OnControllerStateChanged += state => newState = state;

            // Act
            gameLoopController.Step();

            // Assert
            newState.Should().IsSameOrEqualTo(ControllerState.GameOver);
            gameLoopController.Result.Should().IsSameOrEqualTo(StepResult.Collided);
        }
        
        [Theory]
        [AutoMoqData]
        public void PlaceFood_ShouldNeverSpawnOnSnakeBody(
            [Frozen] Mock<IGridModel> gridModel,
            [Frozen] Mock<ISnakeModel> snakeModel,
            FoodSpawner foodSpawner)
        {
            // Arrange
            var snakePositions = new List<Vector2Int>()
            {
                new(0, 0),
                new(0, 1),
                new(1, 0),
            };
            
            var expectedPositionToSpawn = new Vector2Int(1, 1);

            snakeModel.Setup(x => x.Parts).Returns(snakePositions);

            gridModel.Setup(x => x.Height).Returns(2);
            gridModel.Setup(x => x.Width).Returns(2);

            // Act
            var foodModel = foodSpawner.Spawn();

            // Assert
            foodModel.Position.Should().IsSameOrEqualTo(expectedPositionToSpawn);
        }
    }
}

