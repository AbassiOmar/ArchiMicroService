/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.7.0.0 (NJsonSchema v10.1.24.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const APIBFF_BASE_URL = new InjectionToken<string>('APIBFF_BASE_URL');

@Injectable({
    providedIn: 'root'
})
export class BFFProductClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(APIBFF_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    /**
     * @param userName (optional) 
     * @return Success
     */
    getBusketByUserName(userName: string | undefined): Observable<BasketModel> {
        let url_ = this.baseUrl + "/api/Basket/GetBusketByUserName?";
        if (userName === null)
            throw new Error("The parameter 'userName' cannot be null.");
        else if (userName !== undefined)
            url_ += "userName=" + encodeURIComponent("" + userName) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetBusketByUserName(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetBusketByUserName(<any>response_);
                } catch (e) {
                    return <Observable<BasketModel>><any>_observableThrow(e);
                }
            } else
                return <Observable<BasketModel>><any>_observableThrow(response_);
        }));
    }

    protected processGetBusketByUserName(response: HttpResponseBase): Observable<BasketModel> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("Success", status, _responseText, _headers);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = ProblemDetails.fromJS(resultData400);
            return throwException("Bad Request", status, _responseText, _headers, result400);
            }));
        } else if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);
            }));
        } else if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = BasketModel.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<BasketModel>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    basket(body: BasketModel | undefined): Observable<BasketModel> {
        let url_ = this.baseUrl + "/api/Basket";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processBasket(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processBasket(<any>response_);
                } catch (e) {
                    return <Observable<BasketModel>><any>_observableThrow(e);
                }
            } else
                return <Observable<BasketModel>><any>_observableThrow(response_);
        }));
    }

    protected processBasket(response: HttpResponseBase): Observable<BasketModel> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = BasketModel.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<BasketModel>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    checkout(body: BasketCheckoutModel | undefined): Observable<void> {
        let url_ = this.baseUrl + "/api/Basket/Checkout";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCheckout(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCheckout(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else
                return <Observable<void>><any>_observableThrow(response_);
        }));
    }

    protected processCheckout(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return _observableOf<void>(<any>null);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = ProblemDetails.fromJS(resultData400);
            return throwException("Bad Request", status, _responseText, _headers, result400);
            }));
        } else if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<void>(<any>null);
    }

    /**
     * @return Success
     */
    product(): Observable<ProductModel[]> {
        let url_ = this.baseUrl + "/api/Product";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "text/plain"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processProduct(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processProduct(<any>response_);
                } catch (e) {
                    return <Observable<ProductModel[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<ProductModel[]>><any>_observableThrow(response_);
        }));
    }

    protected processProduct(response: HttpResponseBase): Observable<ProductModel[]> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("Success", status, _responseText, _headers);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            let resultData400 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result400 = ProblemDetails.fromJS(resultData400);
            return throwException("Bad Request", status, _responseText, _headers, result400);
            }));
        } else if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);
            }));
        } else if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(ProductModel.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<ProductModel[]>(<any>null);
    }
}

export class BasketCheckoutModel implements IBasketCheckoutModel {
    userName?: string | undefined;
    totalPrice?: number;
    firstName?: string | undefined;
    lastName?: string | undefined;
    emailAddress?: string | undefined;
    addressLine?: string | undefined;
    country?: string | undefined;
    state?: string | undefined;
    zipCode?: string | undefined;
    cardName?: string | undefined;
    cardNumber?: string | undefined;
    expiration?: string | undefined;
    cvv?: string | undefined;
    paymentMethod?: number;

    constructor(data?: IBasketCheckoutModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.userName = _data["userName"];
            this.totalPrice = _data["totalPrice"];
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.emailAddress = _data["emailAddress"];
            this.addressLine = _data["addressLine"];
            this.country = _data["country"];
            this.state = _data["state"];
            this.zipCode = _data["zipCode"];
            this.cardName = _data["cardName"];
            this.cardNumber = _data["cardNumber"];
            this.expiration = _data["expiration"];
            this.cvv = _data["cvv"];
            this.paymentMethod = _data["paymentMethod"];
        }
    }

    static fromJS(data: any): BasketCheckoutModel {
        data = typeof data === 'object' ? data : {};
        let result = new BasketCheckoutModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["userName"] = this.userName;
        data["totalPrice"] = this.totalPrice;
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["emailAddress"] = this.emailAddress;
        data["addressLine"] = this.addressLine;
        data["country"] = this.country;
        data["state"] = this.state;
        data["zipCode"] = this.zipCode;
        data["cardName"] = this.cardName;
        data["cardNumber"] = this.cardNumber;
        data["expiration"] = this.expiration;
        data["cvv"] = this.cvv;
        data["paymentMethod"] = this.paymentMethod;
        return data; 
    }
}

export interface IBasketCheckoutModel {
    userName?: string | undefined;
    totalPrice?: number;
    firstName?: string | undefined;
    lastName?: string | undefined;
    emailAddress?: string | undefined;
    addressLine?: string | undefined;
    country?: string | undefined;
    state?: string | undefined;
    zipCode?: string | undefined;
    cardName?: string | undefined;
    cardNumber?: string | undefined;
    expiration?: string | undefined;
    cvv?: string | undefined;
    paymentMethod?: number;
}

export class BasketItemModel implements IBasketItemModel {
    quantity?: number;
    color?: string | undefined;
    price?: number;
    productId?: string | undefined;
    productName?: string | undefined;

    constructor(data?: IBasketItemModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.quantity = _data["quantity"];
            this.color = _data["color"];
            this.price = _data["price"];
            this.productId = _data["productId"];
            this.productName = _data["productName"];
        }
    }

    static fromJS(data: any): BasketItemModel {
        data = typeof data === 'object' ? data : {};
        let result = new BasketItemModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["quantity"] = this.quantity;
        data["color"] = this.color;
        data["price"] = this.price;
        data["productId"] = this.productId;
        data["productName"] = this.productName;
        return data; 
    }
}

export interface IBasketItemModel {
    quantity?: number;
    color?: string | undefined;
    price?: number;
    productId?: string | undefined;
    productName?: string | undefined;
}

export class BasketModel implements IBasketModel {
    userName?: string | undefined;
    items?: BasketItemModel[] | undefined;
    totalPrice?: number;

    constructor(data?: IBasketModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.userName = _data["userName"];
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items!.push(BasketItemModel.fromJS(item));
            }
            this.totalPrice = _data["totalPrice"];
        }
    }

    static fromJS(data: any): BasketModel {
        data = typeof data === 'object' ? data : {};
        let result = new BasketModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["userName"] = this.userName;
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        data["totalPrice"] = this.totalPrice;
        return data; 
    }
}

export interface IBasketModel {
    userName?: string | undefined;
    items?: BasketItemModel[] | undefined;
    totalPrice?: number;
}

export class ProblemDetails implements IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;

    constructor(data?: IProblemDetails) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.type = _data["type"];
            this.title = _data["title"];
            this.status = _data["status"];
            this.detail = _data["detail"];
            this.instance = _data["instance"];
        }
    }

    static fromJS(data: any): ProblemDetails {
        data = typeof data === 'object' ? data : {};
        let result = new ProblemDetails();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["title"] = this.title;
        data["status"] = this.status;
        data["detail"] = this.detail;
        data["instance"] = this.instance;
        return data; 
    }
}

export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
}

export class ProductModel implements IProductModel {
    id?: string | undefined;
    name?: string | undefined;
    category?: string | undefined;
    summary?: string | undefined;
    description?: string | undefined;
    imageFile?: string | undefined;
    price?: number;

    constructor(data?: IProductModel) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.category = _data["category"];
            this.summary = _data["summary"];
            this.description = _data["description"];
            this.imageFile = _data["imageFile"];
            this.price = _data["price"];
        }
    }

    static fromJS(data: any): ProductModel {
        data = typeof data === 'object' ? data : {};
        let result = new ProductModel();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["category"] = this.category;
        data["summary"] = this.summary;
        data["description"] = this.description;
        data["imageFile"] = this.imageFile;
        data["price"] = this.price;
        return data; 
    }
}

export interface IProductModel {
    id?: string | undefined;
    name?: string | undefined;
    category?: string | undefined;
    summary?: string | undefined;
    description?: string | undefined;
    imageFile?: string | undefined;
    price?: number;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new ApiException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}