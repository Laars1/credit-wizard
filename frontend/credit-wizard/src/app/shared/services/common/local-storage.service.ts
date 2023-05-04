import { Injectable } from '@angular/core';

/**
 * Service for handling local storage data
 */
@Injectable({
    providedIn: 'root'
  })
export class LocalStorageService {

    /**
     * Add an item to the local storage
     * @param key key by which the entry can be found
     * @param value value of the entry
     */
    set(key: string, value: string) {
        localStorage.setItem(key, value);
    }

    /**
     * Get item from localstorage by key
     * @param key key by which the entry can be found
     * @returns a string of the found value, if not found than return null
     */
    get(key: string) {
        return localStorage.getItem(key);
    }

    /**
     * Remove item from local storage by its key
     * @param key key by which the entry can be found
     */
    remove(key: string) {
        localStorage.removeItem(key);
    }
}