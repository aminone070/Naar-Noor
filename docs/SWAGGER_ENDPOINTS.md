# Complete API Endpoints Reference

## All 7 Active Endpoints in Swagger

### 1. **Reviews** (What Our Guests Say)
```
GET /api/reviews
```
- **Purpose**: Fetch all approved customer reviews
- **Status Code**: 200 OK
- **Response**: Array of review objects
- **Used By**: ReviewsComponent
- **Swagger Path**: `/api/docs` → scroll to `reviews` section

### 2. **Chefs** (Meet Our Chefs)
```
GET /api/chefs
```
- **Purpose**: Fetch all active chefs with bios
- **Status Code**: 200 OK
- **Response**: Array of chef objects
- **Used By**: ChefsComponent
- **Swagger Path**: `/api/docs` → scroll to `chefs` section

### 3. **Menu** (Crafted With Passion)
```
GET /api/menu
GET /api/menu?category=Starters
```
- **Purpose**: Fetch menu items (all or by category)
- **Status Code**: 200 OK
- **Query Parameters**: `category` (optional)
- **Response**: Array of menu item objects
- **Used By**: MenuComponent
- **Swagger Path**: `/api/docs` → scroll to `menu` section

### 4. **Reservations** (Book a Table)
```
POST /api/reservations
```
- **Purpose**: Create a table reservation
- **Status Code**: 201 Created
- **Request Body**: Reservation data
- **Response**: `{ id: "uuid" }`
- **Used By**: ReservationComponent
- **Swagger Path**: `/api/docs` → scroll to `reservations` section

### 5. **Contact** (Contact Section)
```
POST /api/contact
```
- **Purpose**: Submit contact inquiry
- **Status Code**: 201 Created
- **Request Body**: Contact message
- **Response**: `{ id: "uuid" }`
- **Used By**: ContactComponent
- **Swagger Path**: `/api/docs` → scroll to `contact` section

### 6. **Orders** (Order Form)
```
POST /api/orders
```
- **Purpose**: Create food order
- **Status Code**: 201 Created
- **Request Body**: Order items and details
- **Response**: `{ id: "uuid" }`
- **Used By**: OrderFormComponent
- **Swagger Path**: `/api/docs` → scroll to `orders` section

### 7. **Health Check** (Monitoring)
```
GET /health
```
- **Purpose**: Check API health status
- **Status Code**: 200 OK
- **Response**: Health status object
- **Swagger Path**: Not in Swagger (system endpoint)

---

## Frontend ↔ Backend Integration

### How Frontend Calls Work

All API calls go through `ApiService` in `src/app/services/api.service.ts`:

```typescript
// Import environment config
import { environment } from '../../environments/environment';

// Base URL is automatically set based on environment:
// Dev: http://localhost:8080/api
// Prod: https://naar-noor.runasp.net/api

private readonly baseUrl = `${environment.apiUrl}/api`;

// Example: getReviews() internally calls:
return this.http.get<Review[]>(`${this.baseUrl}/reviews`);
// Which becomes: http://localhost:8080/api/reviews
// Or in prod: https://naar-noor.runasp.net/api/reviews
```

### Swagger Auto-Discovery

All 7 controller endpoints are **automatically discovered** by Swagger because:

1. ✅ All controllers have `[ApiController]` attribute
2. ✅ All routes follow pattern `[Route("api/[controller]")]`
3. ✅ All HTTP methods have proper attributes (`[HttpGet]`, `[HttpPost]`)
4. ✅ All have `[ProducesResponseType]` for documentation

Result: Swagger automatically generates documentation for all endpoints at `/api/docs`

---

## Accessing Swagger UI

### Development
```
http://localhost:8080/api/docs
```

### Production
```
https://naar-noor.runasp.net/api/docs
```

### Swagger JSON Schema
```
GET /swagger/v1/swagger.json
```
Returns the complete OpenAPI schema used by Swagger UI.

---

## Frontend Section → Backend Endpoint Mapping

| Frontend Section | Component | Endpoint | Method | Purpose |
|-----------------|-----------|----------|--------|---------|
| **What Our Guests Say** | ReviewsComponent | `/api/reviews` | GET | Load reviews |
| **Meet Our Chefs** | ChefsComponent | `/api/chefs` | GET | Load chefs |
| **Crafted With Passion** | MenuComponent | `/api/menu` | GET | Load menu items |
| **Book a Table** | ReservationComponent | `/api/reservations` | POST | Create reservation |
| **Contact Section** | ContactComponent | `/api/contact` | POST | Submit contact |
| **Order Form** | OrderFormComponent | `/api/orders` | POST | Create order |
| **Health Monitoring** | HealthService | `/health` | GET | Check API status |

---

## Error Handling in Frontend

All components handle API errors gracefully:

```typescript
this.api.getReviews().subscribe({
  next: (data) => {
    this.reviews = data;
    this.loading = false;
  },
  error: (err) => {
    this.error = true;        // Show error state
    this.loading = false;     // Hide loading
    // Error message displayed to user
  }
});
```

---

## Backend Controllers Location

```
api-server/src/NaarNoor.API/Controllers/
├── ReviewsController.cs      → GET /api/reviews
├── ChefsController.cs        → GET /api/chefs
├── MenuController.cs         → GET /api/menu
├── ReservationsController.cs → POST /api/reservations
├── ContactController.cs      → POST /api/contact
├── OrdersController.cs       → POST /api/orders
├── HealthController.cs       → GET /health
└── (All auto-discovered by Swagger)
```

---

## Swagger Configuration

### Swagger Service Configuration
**File**: `api-server/src/NaarNoor.API/Configuration/SwaggerServiceConfiguration.cs`
- Registers Swagger with API title and version
- Auto-discovers all `[ApiController]` decorated controllers
- Generates OpenAPI specification

### Swagger Middleware Configuration
**File**: `api-server/src/NaarNoor.API/Middleware/SwaggerMiddleware.cs`
- Serves JSON schema at `/swagger/v1/swagger.json`
- Serves UI at `/api/docs`
- Clean, minimal configuration (removed OpenAPI complexity)

### Program.cs Integration
**File**: `api-server/src/NaarNoor.API/Program.cs`
- Adds Swagger services in startup
- Uses Swagger middleware in pipeline
- Configured before controller routes

---

## Testing the Integration

### 1. Test All Endpoints Load
Visit: `https://naar-noor.vercel.app`

Expected:
- ✅ "What Our Guests Say" loads reviews
- ✅ "Meet Our Chefs" loads chefs
- ✅ "Crafted With Passion" loads menu
- ✅ All forms accept input
- ✅ No "Unable to load" errors

### 2. View API Documentation
Visit: `https://naar-noor.runasp.net/api/docs`

Expected:
- ✅ Swagger UI loads
- ✅ All 7 endpoints visible
- ✅ Can expand each endpoint to see details
- ✅ Can view request/response schemas

### 3. Direct API Testing
```bash
# Get reviews
curl https://naar-noor.runasp.net/api/reviews

# Get chefs
curl https://naar-noor.runasp.net/api/chefs

# Get menu
curl https://naar-noor.runasp.net/api/menu

# Get Swagger schema
curl https://naar-noor.runasp.net/swagger/v1/swagger.json
```
