# Copilot Instructions for testRep

## Project Overview
**testRep** is a minimal testing repository for JSON data management. Current structure contains configuration data in JSON format.

## Key Files & Structure

- `iikoJsonGroup.json` - JSON configuration file containing menu/inventory data (currently: `{"meat": 100}`)
- `fileTest/` - Empty testing directory for future test files
- `README.md` - Project documentation

## Data Format Conventions

When working with JSON files in this repo:
- Use UTF-8 encoding without BOM
- Follow standard JSON formatting: 2-space indentation
- Object keys use lowercase with underscores (e.g., `meat`, `group_name`)
- Numeric values represent quantities or identifiers

Example from `iikoJsonGroup.json`:
```json
{
    "meat": 100
}
```

## Development Patterns

### JSON Modifications
- Always maintain valid JSON syntax when updating data files
- Validate against iiko (POS system) schema if extending data structure
- Test changes in `fileTest/` directory before applying to production data

### Testing Approach
- Place test files and fixtures in the `fileTest/` directory
- Use descriptive filenames for test data (e.g., `iikoJsonGroup.test.json`)

## Build & Validation
- No build system currently configured
- Use JSON validators to check data integrity (e.g., VS Code's built-in JSON validation)

## Next Steps for Expansion
- Define complete JSON schema for iiko data integration
- Add test files demonstrating valid data structures
- Document any external API integrations or dependencies
