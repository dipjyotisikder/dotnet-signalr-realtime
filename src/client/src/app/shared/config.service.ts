import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

export interface IServiceConfig {
    apiBaseUrl: string;
    signalrHubEndpoint: string;
    signalrUrl: string;
}

@Injectable({
    providedIn: 'root',
})
export class ConfigService {
    private configSubject = new BehaviorSubject<IServiceConfig | null>(null);
    public config$: Observable<IServiceConfig | null> = this.configSubject.asObservable();

    constructor() {
        this.loadConfiguration();
    }

    /**
     * Loads configuration from environment file.
     * Configuration is file-driven via the environment.ts files.
     */
    private loadConfiguration(): void {
        const config: IServiceConfig = {
            apiBaseUrl: environment.apiBaseUrl,
            signalrHubEndpoint: environment.signalrHubEndpoint,
            signalrUrl: environment.signalrUrl,
        };

        console.log('Configuration loaded from environment files:', config);
        this.configSubject.next(config);
    }

    /**
     * Gets the current configuration synchronously.
     */
    getConfig(): IServiceConfig | null {
        return this.configSubject.value;
    }

    /**
     * Gets the configuration as an observable.
     */
    getConfig$(): Observable<IServiceConfig | null> {
        return this.config$;
    }

    /**
     * Waits for configuration to be loaded (returns the config when available).
     */
    waitForConfig(): Observable<IServiceConfig> {
        return this.config$.pipe(
            map((config: IServiceConfig | null) => {
                if (!config) {
                    throw new Error('Configuration not loaded');
                }
                return config;
            })
        );
    }
}
