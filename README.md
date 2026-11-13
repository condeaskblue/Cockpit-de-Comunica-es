# Campaign Management – Summary

## 1. Login

| Field | Type | Required |
|---|---|---|
| Username/Email | text | Yes |
| Password | password | Yes |
| Sign in | button (POST) | – |

**Rules:**
- Hide the user token when clicking "Sign in" (visible in Network tab, F12).
- Call the API fetching only ID, Email and Password.

## 2. Campaigns List

**Layout:** page title "Campaigns List", search by ID/Name, status filter (multi-select dropdown), "Create Campaign" button, "Manage Users" button (admin only), "Edit" button next to each campaign.

| ID | Subject/Name | Created Date | Status | Action |
|---|---|---|---|---|
| 19 | IST Exhibition | 12/11/2026 | New | Edit |
| 71 | WebSummit | 07/07/2026 | Closed | Edit |

**Rules:**
- Each user only sees the campaigns they created.
- Regular profile: campaign list only.
- Admin profile: "Manage Users" button.
- Campaign statuses: New, Scheduled, Sending, Closed, For Review, Approved, Cancelled.

## 3. Create / Edit Campaign

| Field | Type |
|---|---|
| Name | text box |
| Description | text box |
| Message Template | text box |
| Date | date picker |
| Campaign Type | text box |
| Services | – (TBD) |
| Image | file selector (png/jpg) |

| Screen | Buttons |
|---|---|
| Create | Back, Create |
| Edit | Back, Save (+ Cancel in header) |

## 4. Approve Campaign

| Left column (read-only) | Right column (Justification) |
|---|---|
| Name | Approved |
| Description | Cancelled |
| Message Template | For Review |
| Date | Reason |
| Type | |
| Services | Dropdown |
| Image | |

**Buttons:** Back, Save (header: Cancel, Approve).

## 5. Cancel Campaign

| Field | Type |
|---|---|
| Name | text box |
| Creator | text box |
| Reason | text box |

**Buttons:** Back, Save.

## 6. Create / Edit Account

| Field | Type |
|---|---|
| Name | text box |
| Email | text box |
| Approver | checkbox (bool) |
| Admin | checkbox (bool) |
| Approving | checkbox (bool) |
| Photo | file selector (png/jpg) |

| Screen | Buttons |
|---|---|
| Create | Back, Create |
| Edit | Back, Save |

## 7. Data Model

### User

| Field | Type | Key |
|---|---|---|
| id | int | PK |
| name | string | |
| email | string | |
| password_hash | string | |
| birth_date | date | |
| tax_id (NIF) | int | |
| is_approver | boolean | |
| is_admin | boolean | |
| is_approving | boolean | |
| photo | file | |

### Campaign

| Field | Type | Key |
|---|---|---|
| id | int | PK |
| user_id | int | FK → User.id |
| name | string | |
| created_at | date | |
| publish_date | date | |
| description | string | |
| type | string | |
| service | string | |
| image | file | |
| status | enum | |

### Approval

| Field | Type | Key |
|---|---|---|
| campaign_id | int | PK, FK → Campaign.id |
| approver_id | int | PK, FK → User.id |
| status | enum | |
| reason | string | |
| justification | string | |

**Relationships:**
- User 1 → N Campaign (via `user_id`)
- Campaign 1 → N Approval (via `campaign_id`)
- User 1 → N Approval (via `approver_id`)

**Status values:** New, Scheduled, Sending, Closed, For Review, Approved, Cancelled.
