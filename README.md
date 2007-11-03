# Society Registration Portal — ERP System

A web-based ERP system for managing society/organization member registrations, hierarchical designations, geographic zones, and reporting.

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
