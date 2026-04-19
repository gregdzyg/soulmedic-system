import React, { useEffect, useState } from 'react';
import { ActivityIndicator, View } from 'react-native';

import { SpecialistDetails, SpecialistListItem } from './src/types/specialist';
import { specialistsService } from './src/services/specialistsService.ts';

import SpecialistsListScreen from './src/screens/SpecialistsListScreen.tsx';
import SpecialistDetailsScreen from './src/screens/SpecialistDetailsScreen.tsx';

function App(): React.JSX.Element {
  const [specialists, setSpecialists] = useState<SpecialistListItem[]>([]);
  const [selected, setSelected] = useState<SpecialistDetails | null>(null);

  const [loadingList, setLoadingList] = useState(true);
  const [loadingDetails, setLoadingDetails] = useState(false);

  useEffect(() => {
    specialistsService
      .getAll()
      .then(setSpecialists)
      .finally(() => setLoadingList(false));
  }, []);

  function handleSelect(id: number) {
    setLoadingDetails(true);

    specialistsService
      .getById(id)
      .then(setSelected)
      .finally(() => setLoadingDetails(false));
  }

  if (loadingList || loadingDetails) {
    return (
      <View style={{ flex: 1, justifyContent: 'center' }}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  if (selected) {
    return (
      <SpecialistDetailsScreen
        specialist={selected}
        onBack={() => setSelected(null)}
      />
    );
  }

  return (
    <SpecialistsListScreen
      specialists={specialists}
      onSelect={handleSelect}
    />
  );
}

export default App;