# AGENT INSTRUCTIONS

This repository hosts a simple layered .NET 9 Product Service. These instructions are for any AI / automated agent contributing code.

## Quick Purpose
Expose an HTTP endpoint to retrieve a Product (by id) and apply an optional discount from an external discount client.

## Layered Architecture (Must Preserve)
1. Core
   - Pure application layer: use cases, contracts (interfaces), mapping helpers, application models.
   - NO references to Api or Infrastructure.
2. Infrastructure
   - Implements Core contracts (repository, discount client, mappers to data / external models).
   - Depends only on Core.
3. Api
   - HTTP surface (controllers / minimal API + API models + API mappers + DI composition root).
   - Depends only on Core.

Violations (e.g., Infrastructure calling Api, or Core referencing Infrastructure) are NOT allowed.

## Naming & Mapping Strategy
- Mapping centralised via extension methods:
  - Core: CoreMapper (data <-> application models).
  - Infrastructure: InfrastructureMapper (source storage / external shapes <-> data layer DTOs used in Core boundary contracts).
  - Api: ApiMapper (application results -> API responses).
- Keep logic inside mappers simple, deterministic, and side-effect free.

## Business Rules (Discount)
- Discount value expected range: 0 < d < 1 (fractional) -> interpret as percentage (0.15 = 15%).
- Apply only when strictly within that range; otherwise ignore.
- Price adjustment: Price = decimal.Round(Price * (1 - d), 2, MidpointRounding.ToEven (default)).
- Do not introduce floating point (double) for price math; keep decimal.

## Use Case (GetProduct)
1. Map ProductQuery -> ProductDataQuery; call IProductRepository.GetById.
2. Map ProductDataResult -> ProductResult.
3. Map ProductQuery -> DiscountDataQuery; call IDiscountClient.GetDiscountForProduct.
4. Apply discount rule.
5. Return ProductResult to Api for mapping to ProductResponse.

## Error Handling (Current State)
- Not-found not yet surfaced as 404 (future enhancement). Avoid speculative error contracts unless explicitly requested.

## Testing Guidance
- Unit tests should mock repository & discount client to cover discount boundaries: negative, 0, (0,1), 1, >1.
- Keep deterministic decimal assertions (avoid culture-specific formatting).
- Mocking framework: NSubstitute (maintain consistency unless a change is explicitly required).

## When Adding Code
- Respect immutability / readonly where feasible.
- Prefer small focused extension methods for transformations.
- Keep public surface minimal; internal where possible (except for DI entry points).
- Adhere to existing folder structure (UseCases/<Name>, Models, Contracts, etc.).

## Dependency Injection
- Register implementations only in Api composition root (Program.cs or dedicated installer). Infrastructure should provide extension methods for registration if needed.

## Performance / Future Considerations
- Potential decorators (caching, logging, validation) should wrap interfaces in Core (e.g., IProductRepository) without breaking layering.
- Avoid premature optimization; prefer clarity.

## Commit Style
- Summaries in English, imperative mood (e.g., "Add discount validation for edge cases").
- Reference issue IDs if applicable.

## Do Not
- Introduce new external packages without necessity.
- Leak Infrastructure or Api types into Core.
- Replace decimal with double for monetary values.
- Use AutoMapper or MediatR libraries; prefer explicit mapping and direct use case invocation to keep clarity and avoid hidden reflection / pipeline overhead.

## Reference
For detailed domain and architectural rationale read: README.md

Keep changes consistent with this contract. If a requirement conflicts with README.md, follow README.md and update this file if needed.
