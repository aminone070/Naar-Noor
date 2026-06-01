/** 
 * API Service Integration Guide
 * Complete mapping of frontend to backend endpoints
 */

import { ApiService } from './api.service';

// ============================================================
// ENDPOINT MAPPING - Frontend to Backend
// ============================================================

/**
 * REVIEWS ENDPOINT
 * ───────────────────────────────────────────────────────
 * Frontend: src/app/sections/reviews/reviews.component.ts
 * Backend: api-server/src/NaarNoor.API/Controllers/ReviewsController.cs
 * 
 * GET /api/reviews
 * - Returns all approved reviews from database
 * - Used by: ReviewsComponent (What Our Guests Say section)
 * - Expected Response:
 *   [
 *     {
 *       id: "uuid",
 *       customerName: "string",
 *       rating: 1-5,
 *       comment: "string",
 *       source: "Google|TripAdvisor|Direct",
 *       createdAt: "ISO-8601 timestamp"
 *     }
 *   ]
 */
// Usage in Frontend:
// this.api.getReviews().subscribe({
//   next: (reviews) => { ... },
//   error: () => { this.error = true; }
// });


/**
 * CHEFS ENDPOINT
 * ───────────────────────────────────────────────────────
 * Frontend: src/app/sections/chefs/chefs.component.ts
 * Backend: api-server/src/NaarNoor.API/Controllers/ChefsController.cs
 * 
 * GET /api/chefs
 * - Returns all active chefs with bios and specialties
 * - Used by: ChefsComponent (Meet Our Chefs section)
 * - Expected Response:
 *   [
 *     {
 *       id: "uuid",
 *       name: "string",
 *       title: "Executive Chef|Sous Chef|Head Pastry Chef",
 *       bio: "string",
 *       imageUrl: "null|string",
 *       specialty: "string",
 *       sortOrder: number
 *     }
 *   ]
 */
// Usage in Frontend:
// this.api.getChefs().subscribe({
//   next: (chefs) => { ... },
//   error: () => { this.error = true; }
// });


/**
 * MENU ENDPOINT
 * ───────────────────────────────────────────────────────
 * Frontend: src/app/sections/menu/menu.component.ts
 * Backend: api-server/src/NaarNoor.API/Controllers/MenuController.cs
 * 
 * GET /api/menu?category=Starters
 * - Returns menu items, optionally filtered by category
 * - Used by: MenuComponent (Menu section)
 * - Query Parameters:
 *   - category: "Starters|Mains|Breads|Desserts|Beverages|Specials" (optional)
 * - Expected Response:
 *   [
 *     {
 *       id: "uuid",
 *       name: "string",
 *       description: "string",
 *       price: number,
 *       category: "string",
 *       isVegetarian: boolean,
 *       isVegan: boolean,
 *       isGlutenFree: boolean,
 *       isAvailable: boolean,
 *       imageUrl: "null|string",
 *       sortOrder: number
 *     }
 *   ]
 */
// Usage in Frontend:
// this.api.getMenu('Starters').subscribe({
//   next: (items) => { ... },
//   error: () => { this.error = true; }
// });


/**
 * RESERVATIONS ENDPOINT
 * ───────────────────────────────────────────────────────
 * Frontend: src/app/sections/reservation/reservation.component.ts
 * Backend: api-server/src/NaarNoor.API/Controllers/ReservationsController.cs
 * 
 * POST /api/reservations
 * - Creates a new table reservation
 * - Used by: ReservationComponent (Book a Table section)
 * - Request Body:
 *   {
 *     customerName: "string",
 *     email: "string",
 *     phoneNumber: "string",
 *     reservationDate: "YYYY-MM-DD",
 *     reservationTime: "HH:MM",
 *     partySize: number,
 *     specialRequests?: "string"
 *   }
 * - Expected Response:
 *   {
 *     id: "uuid"
 *   }
 */
// Usage in Frontend:
// this.api.createReservation(reservationData).subscribe({
//   next: (response) => { success = true; },
//   error: (err) => { error = true; }
// });


/**
 * CONTACT ENDPOINT
 * ───────────────────────────────────────────────────────
 * Frontend: src/app/sections/contact/contact.component.ts
 * Backend: api-server/src/NaarNoor.API/Controllers/ContactController.cs
 * 
 * POST /api/contact
 * - Submits a contact inquiry/message
 * - Used by: ContactComponent (Contact section)
 * - Request Body:
 *   {
 *     name: "string",
 *     email: "string",
 *     phoneNumber?: "string",
 *     subject: "string",
 *     message: "string"
 *   }
 * - Expected Response:
 *   {
 *     id: "uuid"
 *   }
 */
// Usage in Frontend:
// this.api.createContact(contactData).subscribe({
//   next: (response) => { success = true; },
//   error: (err) => { error = true; }
// });


/**
 * ORDERS ENDPOINT
 * ───────────────────────────────────────────────────────
 * Frontend: src/app/components/order-form/order-form.component.ts
 * Backend: api-server/src/NaarNoor.API/Controllers/OrdersController.cs
 * 
 * POST /api/orders
 * - Creates a new order (collection/delivery/dine-in)
 * - Used by: OrderFormComponent
 * - Request Body:
 *   {
 *     customerName: "string",
 *     email: "string",
 *     phoneNumber: "string",
 *     notes?: "string",
 *     type: "collection|delivery|dine-in",
 *     deliveryAddress?: "string",
 *     tableReservationName?: "string",
 *     items: [
 *       {
 *         menuItemId: "uuid",
 *         menuItemName: "string",
 *         unitPrice: number,
 *         quantity: number
 *       }
 *     ]
 *   }
 * - Expected Response:
 *   {
 *     id: "uuid"
 *   }
 */
// Usage in Frontend:
// this.api.createOrder(orderData).subscribe({
//   next: (response) => { success = true; },
//   error: (err) => { error = true; }
// });


/**
 * HEALTH CHECK ENDPOINT
 * ───────────────────────────────────────────────────────
 * Frontend: src/app/services/health.service.ts (optional)
 * Backend: api-server/src/NaarNoor.API/Controllers/HealthController.cs
 * 
 * GET /health
 * - Returns API health status
 * - Used by: Health monitoring, status indicators
 * - Expected Response:
 *   {
 *     status: "Healthy",
 *     checks: { ... }
 *   }
 */
// Usage in Frontend (optional):
// this.api.checkHealth().subscribe({
//   next: (health) => { isHealthy = true; },
//   error: () => { isHealthy = false; }
// });


// ============================================================
// ENVIRONMENT CONFIGURATION
// ============================================================

/**
 * Development Environment (src/environments/environment.ts)
 * ──────────────────────────────────────────────────────────
 * export const environment = {
 *   production: false,
 *   apiUrl: 'http://localhost:8080'
 * };
 * 
 * All endpoints will be called at:
 * - http://localhost:8080/api/reviews
 * - http://localhost:8080/api/chefs
 * - http://localhost:8080/api/menu
 * - http://localhost:8080/api/reservations
 * - http://localhost:8080/api/contact
 * - http://localhost:8080/api/orders
 * - http://localhost:8080/health
 */


/**
 * Production Environment (src/environments/environment.prod.ts)
 * ──────────────────────────────────────────────────────────────
 * export const environment = {
 *   production: true,
 *   apiUrl: 'https://naar-noor.runasp.net'
 * };
 * 
 * All endpoints will be called at:
 * - https://naar-noor.runasp.net/api/reviews
 * - https://naar-noor.runasp.net/api/chefs
 * - https://naar-noor.runasp.net/api/menu
 * - https://naar-noor.runasp.net/api/reservations
 * - https://naar-noor.runasp.net/api/contact
 * - https://naar-noor.runasp.net/api/orders
 * - https://naar-noor.runasp.net/health
 */


// ============================================================
// API ERROR HANDLING
// ============================================================

/**
 * All endpoints handle errors consistently:
 * 
 * GET endpoints (Reviews, Chefs, Menu):
 * - Error: Show error message, disable loading state
 * - Fallback: Display cached data or placeholder
 * 
 * POST endpoints (Reservations, Contact, Orders):
 * - 201 Created: Success, show confirmation
 * - 400 Bad Request: Validation error, show message
 * - 500 Server Error: Show error message, allow retry
 */


// ============================================================
// SWAGGER DOCUMENTATION
// ============================================================

/**
 * Access complete API documentation:
 * 
 * Development: http://localhost:8080/api/docs
 * Production: https://naar-noor.runasp.net/api/docs
 * 
 * All 7 endpoints documented with:
 * - Request/response schemas
 * - Status codes
 * - Example values
 * - Data types
 * 
 * Swagger JSON: /swagger/v1/swagger.json
 */
