# CLAUDE CONTRIBUTION GUIDELINES

This file provides concise instructions for Anthropic Claude (or similar AI assistants) contributing to this repository.

## Primary References (READ FIRST)
- Architectural & domain overview: README.md
- Binding engineering rules & constraints: AGENT.md

If any ambiguity exists:
1. Follow AGENT.md for enforcement details.
2. Cross-check concepts with README.md.
3. If still unclear, prefer the most conservative / minimal-change approach.

## Core Principles (Summary)
- Strict 3-layer architecture: Api -> Core <- Infrastructure (Core isolated from outer layers).
- Explicit mapping (NO AutoMapper). Keep mappings in designated *Mapper extension classes.
- No MediatR pipeline; invoke use cases directly.
- Monetary calculations use decimal only.
- Discount application rules exactly as documented (see AGENT.md & README.md).

## When Making Changes
- Touch only the layer(s) legitimately responsible for the concern.
- Avoid introducing new packages unless essential and aligned with AGENT.md.
- Keep public surface area minimal; use internal where possible.
- Preserve existing naming and folder patterns.

## Tests
- Use NSubstitute for mocks (do not add alternative mocking libs).
- Cover boundary cases for discounts (negative, 0, (0,1), 1, >1).

## Commit Messages
- English, imperative mood (e.g., "Add", "Fix", "Refactor").
- Reference issue ID if available.

## Prohibited
- AutoMapper, MediatR, speculative abstractions, premature optimization.

## If Conflict Detected
Order of authority: README.md (domain) > AGENT.md (rules) > This file (summary). Update this file if it drifts from the authoritative sources.

## Quick Checklist Before Submitting
- [ ] Layering preserved (no forbidden references)
- [ ] Mapping explicit & localized
- [ ] Discount logic unchanged unless task explicitly modifies it
- [ ] Tests updated / added (if logic changed)
- [ ] No disallowed libraries added

Refer back to AGENT.md and README.md for full context whenever in doubt.
