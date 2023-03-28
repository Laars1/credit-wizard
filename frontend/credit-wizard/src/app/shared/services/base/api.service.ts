import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from 'src/environments/environment';

/**
 * Generic api service with methods for different http-methods
 */
@Injectable({
	providedIn: 'root'
})
export class ApiService {
	private readonly baseApiUrl = environment.baseUrl;

	constructor(private http: HttpClient) {}

	/**
	 * Get request to api
	 * @param path Path of endpoint
	 * @returns Observable with response of api
	 */
	public get<TResponse>(path: string): Observable<TResponse> {
		return this.http.get<TResponse>(this.baseApiUrl + path);
	}

	/**
	 * Post request to api
	 * @param path Path of endpoint
	 * @param body Requestbody
	 * @returns Observable with response of api
	 */
	public post<TResponse, TBody = unknown>(
		path: string,
		body: TBody
	): Observable<TResponse> {
		return this.http.post<TResponse>(this.baseApiUrl + path, body);
	}

	/**
	 * Patch request to api
	 * @param path Path of endpoint
	 * @param body Requestbody
	 * @returns Observable with response of api
	 */
	public patch<TResponse, TBody = unknown>(
		path: string,
		body: TBody
	): Observable<TResponse> {
		return this.http.patch<TResponse>(this.baseApiUrl + path, body);
	}

	public put<type>(url: string, body: any): Observable<type> {
		return this.http.put<type>(this.baseApiUrl + url, body);
	}

	/**
	 * Upload request to api
	 * @param path Path of endpoint
	 * @param formData Formdata which should be uploaded
	 * @returns Observable with response of api
	 */
	public upload<TResponse>(
		path: string,
		formData: FormData
	): Observable<TResponse> {
		return this.http.post<TResponse>(this.baseApiUrl + path, formData);
	}

	public delete<type>(url: string): Observable<type> {
		return this.http.delete<type>(this.baseApiUrl + url);
	}
}