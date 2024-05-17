export * from './auth.service';
import { AuthService } from './auth.service';
export * from './availabilitySlots.service';
import { AvailabilitySlotsService } from './availabilitySlots.service';
export * from './bookings.service';
import { BookingsService } from './bookings.service';
export const APIS = [AuthService, AvailabilitySlotsService, BookingsService];
