export type SpecialistListItem = {
  id: number;
  fullName: string;
  specialization: string;
  shortBio?: string | null;
};

export type SpecialistDetails = {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  specialization: string;
  bio: string;
};
