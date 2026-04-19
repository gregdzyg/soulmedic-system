import React from 'react';
import { FlatList, Text, Pressable, View, StyleSheet } from 'react-native';
import ScreenLayout from '../components/ScreenLayout.tsx';
import { SpecialistListItem } from '../types/specialist';

type Props = {
  specialists: SpecialistListItem[];
  onSelect: (id: number) => void;
};

export default function SpecialistsListScreen({ specialists, onSelect }: Props) {
  return (
    <ScreenLayout title="Specjaliści" subtitle="Wybierz specjalistę">
        
      <FlatList
        contentContainerStyle={styles.list}
        data={specialists}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
        <Pressable style={styles.card} onPress={() => onSelect(item.id)}>
         <View style={styles.cardContent}>
            <View style={styles.avatar} />

            <View style={styles.infoContainer}>
                <Text style={styles.name}>{item.fullName}</Text>
                <Text style={styles.specialization}>{item.specialization}</Text>
                {item.shortBio ? (
                    <Text style={styles.shortBio}>{item.shortBio}</Text>
                ) : null
                }

                <Pressable style={styles.button} onPress={() => onSelect(item.id)}>
                <Text style={styles.buttonText}>Zobacz profil</Text>
                </Pressable>
            </View>
         </View>
        </Pressable>
        )}
      />
    </ScreenLayout>
  );
}

const styles = StyleSheet.create({
  list: {
    padding: 16,
    backgroundColor: '#F4F6F9',
  },
  card: {
    backgroundColor: '#FFFFFF',
    borderRadius: 16,
    padding: 16,
    marginBottom: 14,
    borderWidth: 1,
    borderColor: '#E3E6EA',
  },
  cardContent: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  avatar: {
    width: 64,
    height: 64,
    borderRadius: 32,
    backgroundColor: '#D9DCDF',
    marginRight: 14,
  },
  infoContainer: {
    flex: 1,
    justifyContent: 'center',
  },
  name: {
    fontSize: 17,
    fontWeight: '700',
    color: '#212529',
    marginBottom: 4,
  },
  specialization: {
    fontSize: 14,
    color: '#6C757D',
    marginBottom: 10,
  },
  button: {
    alignSelf: 'flex-start',
    borderColor: '#0B3D91',
    borderWidth: 1,
    borderRadius: 8,
    paddingHorizontal: 12,
    paddingVertical: 6,
  },
  buttonText: {
    color: '#0B3D91',
    fontWeight: '600',
    fontSize: 14,
  },
  shortBio: {
  fontSize: 13,
  color: '#6C757D',
  marginBottom: 10,
  lineHeight: 18,
},
});