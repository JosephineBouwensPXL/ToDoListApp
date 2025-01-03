namespace ToDoListApp.Domain.Tests;
[TestFixture]
public class ToDoItemTests
{
    [Test]
    public void CreateNew_ValidDescription_ShouldReturnNewItem_ThatIsNotDone_AndWithIdAndDescription()
    {
        var sut = ToDoItem.CreateNew("test");
        Assert.That(sut.Description, Is.EqualTo("test"));
        Assert.That(sut.IsDone, Is.EqualTo(false));
        Assert.That(sut.Id, Is.Not.EqualTo(Guid.Empty));
    }
    [Test]
    public void CreateNew_DescriptionIsNullOrEmpty_ShouldThrowArgumentException()
    {
        Assert.That(() => ToDoItem.CreateNew(""), Throws.TypeOf<ArgumentException>());
        Assert.That(() => ToDoItem.CreateNew(null), Throws.TypeOf<ArgumentException>());

    }
}