---
applyTo: "tests/**/*.cs"
---

## Test-specific instructions

These instructions apply to all C# test files in the `tests` folder.

- Use xUnit for tests (`[Fact]`, `[Theory]`).
- Name test classes with the `Tests` suffix, for example `OrderPricingServiceTests`.
- Make test names describe the business scenario, not the implementation details.
- Prefer one logical assertion per test method, or a small group of closely related assertions.
- When fixing a bug in `OrderPricingService`, add at least one regression test that fails
  with the old implementation and passes with the new one.
- Keep tests deterministic: do not use random values or time-based logic unless absolutely necessary.
