# NOTE
This repository is a demo project – a lightweight template showcasing the architecture style I use in my services. For a deeper explanation of the principles and evolution of the approach, see my articles:

1. Architecture I Use in My Projects – https://medium.com/@yegor-sychev/architecture-i-use-in-my-projects-60ab8a1b3c45
2. Architecture I Use in My Projects: Continuation – http://medium.com/@yegor-sychev/architecture-i-use-in-my-projects-continuation-37065b8cc870
3. How Clean Architecture Differs From Layered – https://medium.com/@yegor-sychev/how-clean-architecture-differs-from-layered-e11862d073da

---

# ProductService

## Overview
Service that exposes a simple Product retrieval endpoint with discount application. Clean / layered architecture:
- Api: HTTP surface (ASP.NET Core minimal controller layer).
- Core: Application (use cases, business rules, core models, abstractions).
- Infrastructure: Data / external system adapters (repository & external discount client models and mappers).

## Solution Structure
```
/ProductService
  Api/                -> ASP.NET Core project (controllers, API models, DI wiring)
  Core/               -> Use cases, domain-like models, contracts (interfaces), mapping
  Infrastructure/     -> Repository + external client implementations & mappers
  README.md
```

### Layering Rules
- Api depends on Core only.
- Infrastructure depends on Core contracts to implement abstractions.
- Core has no dependency on Api or Infrastructure (inversion via interfaces).

## Key Projects
### Core
Contains:
- Use Cases: e.g. GetProductUseCase (retrieves product & applies discount logic).
- Contracts: IProductRepository, IDiscountClient (+ related query/result DTOs in their own namespaces).
- Models: ProductResult (application-level product representation) & ProductQuery.
- Mappers: CoreMapper (data <-> core model translations).

### Infrastructure
Contains data source / external system shapes and mapping:
- Repository models (ProductSourceModel) mapped to ProductDataResult.
- Mapping helper: InfrastructureMapper.
(Implementations of repository / discount client would live here� not shown if omitted.)

### Api
- ProductController exposes GET /api/product/{id}.
- Api models (ProductResponse) and ApiMapper for mapping from ProductResult.

## Get Product Flow
1. API receives GET request with product id.
2. Controller creates ProductQuery and calls IGetProductUseCase.Execute.
3. Use case:
   - Maps query to ProductDataQuery and calls IProductRepository.GetById.
   - Maps repository ProductDataResult to ProductResult.
   - Maps query to DiscountDataQuery and calls IDiscountClient.GetDiscountForProduct.
   - Applies discount rule (see below) to adjust Price.
4. Result mapped to ProductResponse and returned (HTTP 200).

## Business Rules
- DiscountValue interpretation:
  - Expected fractional range (0,1) exclusive (e.g. 0.15 = 15% off).
  - Only applied when 0 < discount < 1.
  - Outside range -> ignored (base price returned unchanged).
- Price Adjustment: Price = Round(Price * (1 - discount), 2) using midpoint rounding to nearest (default decimal.Round behavior).
- Product identity is integer Id; no additional validation beyond presence in repository (assumed repository throws or handles not-found; controller presently always returns 200� extend for 404 handling if needed).

## Mapping Strategy
- Extension methods centralize transformations (CoreMapper, InfrastructureMapper, ApiMapper) keeping use case & controller logic focused.

## Error Handling (Current Assumptions)
- Not-found and external failures are not yet explicitly surfaced; future enhancement: return ProblemDetails or 404/502 codes.

## Extensibility Points
- Add caching by decorating IProductRepository or IDiscountClient.
- Add validation inside use case (e.g., reject non-positive ids).
- Introduce logging & telemetry in cross-cutting layer.

## Testing Guidance
- Unit test GetProductUseCase with mocked IProductRepository / IDiscountClient verifying discount application boundaries (0, between 0 and 1, 1, >1, negative).
- API integration test for nominal path.

## Build & Run (Typical)
```
dotnet restore
dotnet build
cd Api
dotnet run
```
GET http://localhost:5000/api/product/{id}

## Future Improvements
- Add OpenAPI/Swagger (Swashbuckle) for automatic contract docs.
- Introduce value objects (Money, Percentage) for stronger invariants.
- Implement proper 404 handling and error contracts.
- Add CI pipeline & code quality analyzers.
