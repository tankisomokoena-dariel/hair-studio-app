/**
 * API
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 *//* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent }                           from '@angular/common/http';
import { CustomHttpUrlEncodingCodec }                        from '../encoder';

import { Observable }                                        from 'rxjs';


import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class AuthService {

    protected basePath = '/';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (basePath) {
            this.basePath = basePath;
        }
        if (configuration) {
            this.configuration = configuration;
            this.basePath = basePath || configuration.basePath || this.basePath;
        }
    }

    /**
     * @param consumes string[] mime-types
     * @return true: consumes contains 'multipart/form-data', false: otherwise
     */
    private canConsumeForm(consumes: string[]): boolean {
        const form = 'multipart/form-data';
        for (const consume of consumes) {
            if (form === consume) {
                return true;
            }
        }
        return false;
    }


    /**
     * 
     * 
     * @param contactNo 
     * @param email 
     * @param password 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public loginPost(contactNo?: string, email?: string, password?: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public loginPost(contactNo?: string, email?: string, password?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public loginPost(contactNo?: string, email?: string, password?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public loginPost(contactNo?: string, email?: string, password?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {




        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (contactNo !== undefined && contactNo !== null) {
            queryParameters = queryParameters.set('ContactNo', <any>contactNo);
        }
        if (email !== undefined && email !== null) {
            queryParameters = queryParameters.set('Email', <any>email);
        }
        if (password !== undefined && password !== null) {
            queryParameters = queryParameters.set('Password', <any>password);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('post',`${this.basePath}/login`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param firstName 
     * @param lastName 
     * @param email 
     * @param contactNo 
     * @param password 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public registerPost(firstName?: string, lastName?: string, email?: string, contactNo?: string, password?: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public registerPost(firstName?: string, lastName?: string, email?: string, contactNo?: string, password?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public registerPost(firstName?: string, lastName?: string, email?: string, contactNo?: string, password?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public registerPost(firstName?: string, lastName?: string, email?: string, contactNo?: string, password?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {






        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (firstName !== undefined && firstName !== null) {
            queryParameters = queryParameters.set('FirstName', <any>firstName);
        }
        if (lastName !== undefined && lastName !== null) {
            queryParameters = queryParameters.set('LastName', <any>lastName);
        }
        if (email !== undefined && email !== null) {
            queryParameters = queryParameters.set('Email', <any>email);
        }
        if (contactNo !== undefined && contactNo !== null) {
            queryParameters = queryParameters.set('ContactNo', <any>contactNo);
        }
        if (password !== undefined && password !== null) {
            queryParameters = queryParameters.set('Password', <any>password);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('post',`${this.basePath}/register`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}