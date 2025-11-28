# Copilot instructions for iiko-order-pricing-demo

This repository contains a small C#/.NET 8 library that models restaurant orders
and calculates totals with per-item discounts and a service charge.

## Build and test

- The project uses .NET 8 and the `dotnet` CLI.
- To restore dependencies, run:

  - `dotnet restore src/IikoOrderPricing/IikoOrderPricing.csproj`
  - `dotnet restore tests/IikoOrderPricing.Tests/IikoOrderPricing.Tests.csproj`

- To build the code, run:

  - `dotnet build src/IikoOrderPricing/IikoOrderPricing.csproj -c Release`
  - `dotnet build tests/IikoOrderPricing.Tests/IikoOrderPricing.Tests.csproj -c Release`

- To run tests, run:

  - `dotnet test tests/IikoOrderPricing.Tests/IikoOrderPricing.Tests.csproj -c Release`

When you propose changes, ensure that:
- The solution builds successfully.
- All tests pass and new logic is covered by tests.

## Repository structure

- `src/IikoOrderPricing` — domain models and services.
  - `Models/Order.cs` and `Models/OrderItem.cs` — basic restaurant order model.
  - `Services/OrderPricingService.cs` — pricing logic.
- `tests/IikoOrderPricing.Tests` — xUnit tests that validate pricing behavior.

## Coding standards

- Use explicit, descriptive names for methods and variables.
- Prefer pure functions and deterministic logic for pricing calculations.
- Avoid magic numbers. If you need constants, declare them clearly.
- Keep public APIs small and focused.
- When fixing a bug, always add or update at least one regression test.

## Testing guidelines

- New business logic in `OrderPricingService` must be covered by unit tests.
- Do not weaken existing assertions when fixing behavior.
- If you change the pricing rules, update tests to reflect the new expected behavior
  and explain the reasoning in the pull request description.

## Documentation and pull requests

- In pull request descriptions, briefly explain:
  - Which scenario in the restaurant domain you are changing (for example, how service charge is applied).
  - How you tested your changes (commands, test names).
- Keep pull requests focused on a single cohesive change.
