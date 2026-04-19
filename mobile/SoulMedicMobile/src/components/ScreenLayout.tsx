import React from 'react';
import {
  View,
  Text,
  StyleSheet,
  StatusBar,
  Image,
  Pressable,
} from 'react-native';
import { SafeAreaView } from 'react-native-safe-area-context';

import logo from '../assets/images/logo.png';

type Props = {
  title: string;
  children: React.ReactNode;
};

export default function ScreenLayout({ title, children }: Props): React.JSX.Element {
  return (
    <SafeAreaView style={styles.container}>
      <StatusBar barStyle="dark-content" />

      <View style={styles.header}>
        <View style={styles.leftSection}>
          <Image source={logo} style={styles.logoImage} />
          <Text style={styles.brandText}>SOULMEDIC</Text>
        </View>

        <View style={styles.centerSection}>
          <Text style={styles.screenTitle}>{title}</Text>
        </View>

        <Pressable style={styles.rightSection}>
          <Text style={styles.menuIcon}>☰</Text>
        </Pressable>
      </View>

      <View style={styles.content}>{children}</View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#F4F6F9',
  },
  header: {
    height: 72,
    backgroundColor: '#FFFFFF',
    borderBottomWidth: 1,
    borderBottomColor: '#E3E6EA',
    flexDirection: 'row',
    alignItems: 'center',
    paddingHorizontal: 12,
  },
  leftSection: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
  },
  centerSection: {
    flex: 1,
    alignItems: 'center',
  },
  rightSection: {
    flex: 1,
    alignItems: 'flex-end',
    justifyContent: 'center',
  },
  logoImage: {
    width: 24,
    height: 24,
    marginRight: 6,
    resizeMode: 'contain',
  },
  brandText: {
    fontSize: 14,
    fontWeight: '700',
    color: '#212529',
  },
  screenTitle: {
    fontSize: 18,
    fontWeight: '700',
    color: '#0B3D91',
  },
  menuIcon: {
    fontSize: 22,
    color: '#0B3D91',
    fontWeight: '600',
  },
  content: {
    flex: 1,
  },
});