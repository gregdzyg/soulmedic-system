import { apiService } from './apiService.ts';
import { SpecialistDetails, SpecialistListItem } from '../types/specialist.ts';

export const specialistsService = {
  getAll: () => apiService.get<SpecialistListItem[]>('/specialists'),
  getById: (id: number) => apiService.get<SpecialistDetails>(`/specialists/${id}`),
};