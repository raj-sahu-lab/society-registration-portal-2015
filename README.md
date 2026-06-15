# Society Registration Portal — ERP System

> **Built:** 2007–2008 · ASP.NET 3.5 WebForms · C# · SQL Server
>
> This is one of the earliest projects in this portfolio, built in 2007–2008 to manage society/organisation registrations and member hierarchies for a real NGO. It represents early professional .NET development before parameterised queries and password hashing were standard practice. The codebase has been updated (June 2026) with full SQL parameterisation across 45 files (~100 queries), PBKDF2 password hashing, and a file upload extension whitelist — while preserving the original 2007 architecture.

A web-based ERP system for managing society/organization member registrations, hierarchical designations, geographic zones, and reporting.

> **Note:** This is a 2007–2008 portfolio codebase. Authentication uses direct SQL queries and passwords are stored without modern hashing — these would be the first things hardened before any production deployment today.

## Built: 2007

## Tech Stack

- **Backend:** ASP.NET 3.5 (C#)
- **Database:** SQL Server
- **Frontend:** ASP.NET WebForms, AJAX Control Toolkit, JavaScript
- **Authentication:** Forms-based with role separation (Admin/User)

## Features

### Admin Module
- **Member Registration** — Complete member lifecycle with 80+ data fields (personal, professional, organizational history)
- **Geographic Hierarchy** — Country → State → District → City → Zone → Village master data management
- **Organization Management** — Designation hierarchy, work area assignments, level tracking
- **Reporting Engine** — Reports by qualification, occupation, specialization, age, area, organization, designation
- **Login & Password Management** — User credential administration

### User Module
- Profile viewing and password change
- Personal record access

### Public Pages
- About, Services, FAQs, Contact
- Forgot Password/ID recovery via email

## Architecture

```
├── Admin/          — Admin ASPX pages + master page
├── User/           — User-facing pages
├── App_Code/       — Data access layer (classDB.cs), Tree utilities
├── Bin/            — Compiled assemblies (AjaxControlToolkit)
├── css/            — Stylesheets
├── js/             — Client-side scripts (date picker, MD5 hashing)
├── Images/         — UI assets
└── web.config      — Configuration with connection string placeholder
```

## Setup

1. Create a SQL Server database and run the schema scripts
2. Update `web.config` connection string (`BITRSS`) with your DB credentials
3. Deploy to IIS with ASP.NET 3.5 enabled
4. Access via browser — default login page at `Default.aspx`

## Configuration

Database connection is configured in `web.config`:
```xml
<add name="BITRSS" connectionString="Data Source=[DB_HOST];Initial Catalog=[DB_NAME];User ID=[DB_USER];Password=[DB_PASSWORD];" />
```

## Note

This was one of my earliest production systems — built for a real organization to manage thousands of member registrations across multiple geographic regions. The architecture reflects 2007-era ASP.NET patterns (WebForms, inline SQL, code-behind model).

---

© 2015 Raj Sahu
