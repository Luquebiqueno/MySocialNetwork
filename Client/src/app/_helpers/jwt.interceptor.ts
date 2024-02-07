import { HttpInterceptorFn } from '@angular/common/http';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
	let usuarioAutenticado = JSON.parse(localStorage.getItem('usuarioAutenticado'));

	if (usuarioAutenticado && usuarioAutenticado.accessToken) {
		req = req.clone({
			headers: req.headers.set('Authorization', `Bearer ${usuarioAutenticado.accessToken}`)
		});
	}
	return next(req);
};
