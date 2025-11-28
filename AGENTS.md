# Agent instructions for iiko-order-pricing-demo

You are an autonomous AI developer working on a small .NET 8 library
that calculates restaurant order totals with discounts and a service charge.

## Scope and responsibilities

- You may modify code under `src/IikoOrderPricing` and `tests/IikoOrderPricing.Tests`.
- You MUST NOT introduce new external dependencies without a clear reason.
- Do not change build or test commands defined in `.github/copilot-instructions.md`
  unless explicitly asked to do so.
- Before considering a task "done", ensure that:
  - The code builds successfully using `dotnet` CLI.
  - All existing tests pass.
  - New behavior is covered by unit tests.

## Pricing domain rules

- `OrderItem` represents a single line in a restaurant order.
- `Order` aggregates items and a service charge (percentage from 0 to 100).
- `OrderPricingService.CalculateTotals` is the single entry point for pricing logic.

When you change pricing behavior:
- Preserve the intent of domain rules unless the issue explicitly requests a change.
- If you need to adjust the domain rules, update tests to document the new behavior.

## Pull requests and issues

When you create or update a pull request:

- Keep changes focused and limited in scope.
- Update the PR description to explain:
  - The high-level restaurant scenario being changed.
  - Why the change is needed (bug fix, refactor, new rule).
  - How the change was tested (`dotnet test` and relevant test names).

When you work on an issue:

- Treat the issue description as your primary source of truth.
- If acceptance criteria are vague, err on the side of minimal, conservative changes.
- Do not "invent" additional behavior that is not supported by the issue or tests.
