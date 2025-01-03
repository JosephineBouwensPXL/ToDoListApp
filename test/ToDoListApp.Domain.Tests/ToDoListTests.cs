namespace ToDoListApp.Domain.Tests
{
    [TestFixture]
    public class ToDoListTests
    {
        [Test]
        public void CreateNew_ValidTitle_ShouldReturnNewListWithIdAndTitle()
        {
            var toDolist = ToDoList.CreateNew("title");
            Assert.That(toDolist.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(toDolist.Title, Is.EqualTo("title"));

        }
        [Test]
        public void CreateNew_TitleIsNullOrEmpty_ShouldThrowArgumentException()
        {
            Assert.That(() => ToDoList.CreateNew(""), Throws.TypeOf<ArgumentException>());
            Assert.That(() => ToDoList.CreateNew(null), Throws.TypeOf<ArgumentException>());
        }
    }
}