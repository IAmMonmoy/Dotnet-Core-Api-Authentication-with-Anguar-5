import { HttpErrorResponse } from '@angular/common/http';
import { ErrorObservable } from "rxjs/observable/ErrorObservable";


export class BaseService {

	constructor() { }
	protected handleError(error: HttpErrorResponse): ErrorObservable {

		var modelStateErrors: string = '';
		
		if (error.error instanceof ErrorEvent) {
			// A client-side or network error occurred. Handle it accordingly.
			console.error('An error occurred:', error.error.message);
		} else {
			var serverError = error.error;
			if (serverError != null) {
				for (var key1 in serverError) {
					if (serverError[key1])
						modelStateErrors += serverError[key1][0] + '\n';
				}
			}
			modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
		}
		//return an ErrorObservable with a user-facing error message
		return new ErrorObservable(
			modelStateErrors || 'Something bad happened; please try again later.');
	};
}
