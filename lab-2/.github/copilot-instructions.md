# Workspace AI Instructions

## UI/UX Design Delegation

**CRITICAL: For ANY request that creates or changes UI, views, layouts, CSS, or other user-facing screens:**

1. **Spawn the UX Designer agent** using `runSubagent` with:
   - Task: Design the UI component/page
   - Context: The feature requirements and user needs
   - Reference: ux-designer-instructions.md

2. **Use the UX result as design contract** — implement exactly as specified by UX Designer
3. **Log the UX delegation** — add entry to agent_log.txt when spawning

## General Principles

- Prefer reusable, accessible, responsive patterns over one-off visual fixes
- Keep visual style modern, neutral, and professional
- Keep read-only surfaces clean: suppress informational/success banners and non-essential notifications
- Loading and empty states stay silent by default unless they block use; error states remain visible and actionable
- Commit all UI instructions and patterns to `.github/` for consistency

## Logging & Evidence

- Log UX Designer spawning to agent_log.txt with timestamp and feature name
- Document design decisions in code comments
- Keep audit trail of UI changes linked to requirements
