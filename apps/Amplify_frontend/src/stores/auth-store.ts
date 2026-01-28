import { create } from "zustand";
import { persist, createJSONStorage } from 'zustand/middleware';

interface AuthState {
  accessToken: string | null;
  isAuthenticated: boolean;
  setToken: (token: string) => void;
  logout: () => void;
}

export const useAuthStore = create<AuthState>()(
  persist(
    (set) => ({
      accessToken: null,
      isAuthenticated: false, 

      setToken: (token: string) => set({ 
        accessToken: token, 
        isAuthenticated: true 
      }),

      logout: () => set({ 
        accessToken: null, 
        isAuthenticated: false 
      }),
    }),
    {
      name: 'amplify-auth-storage',
      storage: createJSONStorage(() => localStorage),
    }
  )
);