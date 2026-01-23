# Expense-Management-System

## Problem Statement
Organizations need a secure and auditable way to manage employee expenses. Manual process leads to:
- Delayed reimbursements
- Lack of transparency
- Missing audit trails
- Poor visibility for managers and finance teams

This project is a **production-style backend system** that enables employees to submit expenses, managers to approve or reject them, and finance teams to track and report expenses efficiently.

## High-Level Architecture
![Architecture Diagram](docs/architecture.jpg)

## Architecture Overview
### Client Layer
- Postman (API testing)
- Web UI
  - Employee
  - Manager
  - Admin

### API Layer
- RESTful Web APIs
- JWT Authentication
- Role-based Authorization

Controllers:
- AuthController
- UsersController
- ExpensesController
- ApprovalController

### Application Layer (Business Logic)
- Contains all business rules
- Handles:
  - Expense workflows
  - Approval process
  - Status transitions
  - Validation checks

Services:
- AuthService
- ExpenseService
- ApprovalService

### Infrastructure Layer
- Entity Framework Core
- SQL Server access via DbContext
- Repository implementation
- AWS SDK (S3 for receipts)
- Logging

## Planned Features
- Expense Submission & Tracking
- Upload Receipt to S3
- Approval/Rejection Workflow
- Audit logging
- Email notifications



