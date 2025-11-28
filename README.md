# iiko-order-pricing-demo

Учебный проект для демонстрации работы GitHub Copilot coding agent
на примере простой POS-логики из ресторанного домена.

Функционал:
- Модели заказа и позиций (Order, OrderItem) для ресторана.
- Сервис `OrderPricingService`, который считает:
  - сумму по позициям (subtotal);
  - общую сумму скидок;
  - сервисный сбор в процентах от суммы после скидок;
  - итоговую сумму заказа.

Технологии:
- .NET 8
- xUnit для модульных тестов

Структура:
- `src/IikoOrderPricing` — доменная логика и сервисы.
- `tests/IikoOrderPricing.Tests` — модульные тесты.

Репозиторий подготовлен с учётом рекомендаций из статьи
"Best practices for using GitHub Copilot to work on tasks":
- `.github/copilot-instructions.md` — репозиторные инструкции для Copilot.
- `.github/instructions/tests.instructions.md` — отдельные правила для тестов.
- `.github/workflows/copilot-setup-steps.yml` — подготовка окружения для coding agent.
- `AGENTS.md` — роли, ограничения и ожидания от Copilot coding agent в этом репозитории.
