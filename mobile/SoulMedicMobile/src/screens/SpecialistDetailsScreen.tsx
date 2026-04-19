import React from 'react';
import { Text, View, StyleSheet, ScrollView, Pressable } from 'react-native';
import ScreenLayout from '../components/ScreenLayout.tsx';
import { SpecialistDetails } from '../types/specialist';

type Props = {
  specialist: SpecialistDetails;
  onBack: () => void;
};

export default function SpecialistDetailsScreen({ specialist, onBack }: Props) {
  return (
    <ScreenLayout title="Profil">
      <ScrollView contentContainerStyle={styles.container}>
        <Pressable onPress={onBack}>
          <Text style={styles.back}>← Wróć</Text>
        </Pressable>

        <View style={styles.card}>
          {/* Placeholder zdjęcia */}
          <View style={styles.avatar} />

          <Text style={styles.name}>
            {specialist.firstName} {specialist.lastName}
          </Text>

          <Text style={styles.specialization}>
            {specialist.specialization}
          </Text>

          <View style={styles.contactSection}>
            <Text style={styles.sectionTitle}>Kontakt</Text>

            <Text style={styles.label}>Email</Text>
             <Text style={styles.value}>{specialist.email}</Text>

            <Text style={styles.label}>Telefon</Text>
            <Text style={styles.value}>{specialist.phoneNumber}</Text>
          </View>

          <View style={styles.bioSection}>
            <Text style={styles.sectionTitle}>O specjaliście</Text>
            <Text style={styles.bioText}>{specialist.bio}</Text>
          </View>

          <Pressable style={styles.ctaButton}>
            <Text style={styles.ctaText}>Umów wizytę</Text>
          </Pressable>

        </View>
      </ScrollView>
    </ScreenLayout>
  );
}

const styles = StyleSheet.create({
  container: {
    padding: 16,
    backgroundColor: '#F4F6F9',
  },
  back: {
    color: '#0B3D91',
    marginBottom: 12,
    fontWeight: '600',
    fontSize: 14,
  },
  card: {
    backgroundColor: '#FFFFFF',
    borderRadius: 16,
    padding: 20,
    borderWidth: 1,
    borderColor: '#E3E6EA',
    alignItems: 'center',
  },
  avatar: {
    width: 90,
    height: 90,
    borderRadius: 45,
    backgroundColor: '#D9DCDF',
    marginBottom: 16,
  },
  name: {
    fontSize: 22,
    fontWeight: '700',
    color: '#212529',
    textAlign: 'center',
  },
  specialization: {
    fontSize: 15,
    color: '#6C757D',
    marginTop: 4,
    marginBottom: 18,
    textAlign: 'center',
  },
  section: {
    width: '100%',
    marginTop: 10,
  },
  label: {
    fontSize: 12,
    fontWeight: '700',
    color: '#6C757D',
    marginBottom: 4,
  },
  value: {
    fontSize: 15,
    color: '#212529',
    lineHeight: 22,
  },
  ctaButton: {
    marginTop: 24,
    borderColor: '#0B3D91',
    borderWidth: 1,
    borderRadius: 10,
    paddingVertical: 12,
    paddingHorizontal: 24,
    alignItems: 'center',
    justifyContent: 'center',
  },
  ctaText: {
    color: '#0B3D91',
    fontWeight: '700',
    fontSize: 15,
  },
  sectionTitle: {
  fontSize: 14,
  fontWeight: '700',
  color: '#0B3D91',
  marginBottom: 6,
},

bioSection: {
  width: '100%',
  marginTop: 16,
},

bioText: {
  fontSize: 15,
  color: '#212529',
  lineHeight: 22,
},

contactSection: {
  width: '100%',
  marginTop: 16,
},
});