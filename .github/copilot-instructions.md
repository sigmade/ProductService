# Copilot Project Instructions

Testing Guidance
- Use NSubstitute for mocking interfaces instead of writing manual fakes.
- Avoid hand-written stub classes unless a custom behavior is complex or you need state-based verification not easily expressed with NSubstitute.

General Conventions
- Keep use cases thin; they should delegate to repositories/services.
- Prefer constructor injection (Primary constructors in C# 12/13 are acceptable).
- Return domain models from use cases; map to transport models at API layer.

Pull Request Expectations
- Unit tests required for new use cases and controllers.
- When adding new interfaces, add at least one test using NSubstitute verifying interaction (e.g. Received calls).

Examples
```csharp
[Fact]
public async Task Executes_Call_Repository()
{
    var repo = Substitute.For<IProductRepository>();
    var expected = new Product { Id = 7, Name = "Item", Price = 12.34m };
    repo.GetById(7).Returns(expected);
    var sut = new GetProductUseCase(repo);

    var result = await sut.Execute(7);

    Assert.Same(expected, result);
    await repo.Received(1).GetById(7);
}
```

Packages
- If not already referenced, add: <PackageReference Include="NSubstitute" Version="*" /> to the test project.

Keep instructions concise; update this file when introducing new architectural patterns.