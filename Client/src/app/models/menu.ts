import { MenuItem } from "./menu-item";

export class Menu {
    descricao: string;
    icone: string;
    routerLink?: string;
    children?: MenuItem[];
}
