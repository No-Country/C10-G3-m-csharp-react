import { configureStore } from '@reduxjs/toolkit';
import {registerSlice} from './features/user';


export const store = configureStore({
  reducer: {
    cleanRegister: registerSlice.reducer,
  },
})