/**
 * backend API
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { BaseEntity } from './baseEntity';
import { BaseEvent } from './baseEvent';

export interface BaseAuditableEntity extends BaseEntity { 
    created?: Date;
    createdBy?: string;
    lastModified?: Date;
    lastModifiedBy?: string;
}