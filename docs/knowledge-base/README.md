# Anco1 Knowledge Base

This directory is the durable technical memory for humans and AI agents working on Anco1. It explains project structure, conventions, business rules, dependencies, and decisions that are expensive to rediscover from scratch.

It does **not** replace the source code or database. Current executable code and the current database/schema remain the source of truth for behavior.

Anco1 is structurally similar to the DalatHoa system, but this repository must be treated as its own product. Reuse architectural understanding where verified; never import DalatHoa business rules by assumption.

## Documents

- `ARCHITECTURE.md`: project structure, major layers, and their responsibilities.
- `CONVENTIONS.md`: implementation patterns and constraints that should be preserved during local changes.
- `BUSINESS_LOGIC.md`: durable Anco1 domain rules and cross-module behavior as they are verified over time.
- `DECISIONS.md`: ADR-style record of decisions future agents should not accidentally reverse.

## Confidence labels

### Confirmed

Use when the statement is explicitly confirmed by the project owner or directly established from authoritative current code/database behavior.

### Inferred

Use when the statement is a reasonable conclusion from partial source, naming, repository structure, or similarity to DalatHoa but has not been fully verified.

Never rely on an Inferred item for a consequential change without inspecting the relevant current implementation first.

## How agents should work

1. Read root `AGENTS.md`.
2. Read `ARCHITECTURE.md` and `CONVENTIONS.md`.
3. Read the relevant domain section in `BUSINESS_LOGIC.md`.
4. Inspect the current files, entity mappings, SQL objects, and browser flow related to the task.
5. Implement the narrowest consistent change.
6. Update this knowledge base when the task establishes durable project knowledge.

## What belongs here

Add information that materially reduces rediscovery in future work, for example:

- responsibilities of a project layer or directory,
- non-obvious data flow between modules,
- a business rule that affects multiple code paths,
- a convention required to keep jqGrid/WebForms modules consistent,
- a decision with meaningful consequences,
- a stable implementation pointer for a rule.

## What does not belong here

Do not add temporary debugging output, unsupported assumptions, copied functions, task chatter, or generic framework documentation.
