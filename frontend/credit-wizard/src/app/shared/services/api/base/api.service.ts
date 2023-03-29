import {HttpClient, HttpHeaders} from '@angular/common/http';
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
	private readonly httpOptions = {
		headers: new HttpHeaders({
		  'Content-Type':  'application/json',
		})}
	constructor(private http: HttpClient) {
	}

	/**
	 * Get request to api
	 * @param path Path of endpoint
	 * @returns Observable with response of api
	 */
	public get<TResponse>(path: string): Observable<TResponse> {
		return this.http.get<TResponse>(this.baseApiUrl + path, this.httpOptions);
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
		return this.http.post<TResponse>(this.baseApiUrl + path, body, this.httpOptions);
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
		return this.http.patch<TResponse>(this.baseApiUrl + path, body, this.httpOptions);
	}

	public put<type>(url: string, body: any): Observable<type> {
		return this.http.put<type>(this.baseApiUrl + url, body, this.httpOptions);
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
		return this.http.post<TResponse>(this.baseApiUrl + path, formData, this.httpOptions);
	}

	public delete<type>(url: string): Observable<type> {
		return this.http.delete<type>(this.baseApiUrl + url, this.httpOptions);
	}
}