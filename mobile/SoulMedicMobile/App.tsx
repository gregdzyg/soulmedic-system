import React, { useEffect, useState } from 'react';
import {
  SafeAreaView,
  Text,
  FlatList,
  ActivityIndicator,
  View,
  StyleSheet,
  Pressable,
  ScrollView,
} from 'react-native';

type SpecialistListItem = {
  id: number;
  fullName: string;
  specialization: string;
};

type SpecialistDetails = {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  specialization: string;
  bio: string;
};

function App(): React.JSX.Element {
  const [specialists, setSpecialists] = useState<SpecialistListItem[]>([]);
  const [selectedSpecialist, setSelectedSpecialist] = useState<SpecialistDetails | null>(null);

  const [loadingList, setLoadingList] = useState(true);
  const [loadingDetails, setLoadingDetails] = useState(false);

  useEffect(() => {
    fetch('http://10.0.2.2:5020/api/specialists')
      .then(res => res.json())
      .then(json => setSpecialists(json))
      .catch(err => console.error('Error loading specialists list:', err))
      .finally(() => setLoadingList(false));
  }, []);

  function loadSpecialistDetails(id: number) {
    setLoadingDetails(true);

    fetch(`http://10.0.2.2:5020/api/specialists/${id}`)
      .then(res => res.json())
      .then(json => setSelectedSpecialist(json))
      .catch(err => console.error('Error loading specialist details:', err))
      .finally(() => setLoadingDetails(false));
  }

  function handleBackToList() {
    setSelectedSpecialist(null);
  }

  if (loadingList) {
    return (
      <View style={styles.center}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  if (loadingDetails) {
    return (
      <View style={styles.center}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  if (selectedSpecialist) {
    return (
      <SafeAreaView style={styles.container}>
        <ScrollView contentContainerStyle={styles.detailsContainer}>
          <Pressable style={styles.backButton} onPress={handleBackToList}>
            <Text style={styles.backButtonText}>← Wróć</Text>
          </Pressable>

          <Text style={styles.detailsName}>
            {selectedSpecialist.firstName} {selectedSpecialist.lastName}
          </Text>

          <Text style={styles.detailsLabel}>Specjalizacja</Text>
          <Text style={styles.detailsValue}>{selectedSpecialist.specialization}</Text>

          <Text style={styles.detailsLabel}>Email</Text>
          <Text style={styles.detailsValue}>{selectedSpecialist.email}</Text>

          <Text style={styles.detailsLabel}>Telefon</Text>
          <Text style={styles.detailsValue}>{selectedSpecialist.phoneNumber}</Text>

          <Text style={styles.detailsLabel}>Bio</Text>
          <Text style={styles.detailsValue}>{selectedSpecialist.bio}</Text>
        </ScrollView>
      </SafeAreaView>
    );
  }

  return (
    <SafeAreaView style={styles.container}>
      <FlatList
        data={specialists}
        keyExtractor={item => item.id.toString()}
        renderItem={({ item }) => (
          <Pressable style={styles.card} onPress={() => loadSpecialistDetails(item.id)}>
            <Text style={styles.name}>{item.fullName}</Text>
            <Text style={styles.specialization}>{item.specialization}</Text>
          </Pressable>
        )}
      />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  card: {
    padding: 16,
    borderBottomWidth: 1,
    borderBottomColor: '#ccc',
  },
  name: {
    fontSize: 20,
    fontWeight: '700',
    marginBottom: 4,
  },
  specialization: {
    fontSize: 16,
    color: '#444',
  },
  center: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  detailsContainer: {
    padding: 20,
  },
  backButton: {
    marginBottom: 20,
  },
  backButtonText: {
    fontSize: 16,
    color: '#007AFF',
    fontWeight: '600',
  },
  detailsName: {
    fontSize: 28,
    fontWeight: '700',
    marginBottom: 20,
  },
  detailsLabel: {
    fontSize: 14,
    fontWeight: '700',
    marginTop: 14,
    marginBottom: 4,
    color: '#555',
  },
  detailsValue: {
    fontSize: 16,
    color: '#222',
    lineHeight: 22,
  },
});

export default App;