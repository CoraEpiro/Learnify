import { post } from "./request.js";

export const login = (data) => post("auth/login", data);
export const register = (data) => post("auth/register", data);
