export const navigation = [
  {
    text: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Tareas',
    icon: 'folder',
    items: [
      {
        text: 'Perfil',
        path: '/profile'
      },
      {
        text: 'Productos',
        path: '/tasks'
      },
      {
        text: 'Factura',
        path: '/factura'
      }
    ]
  },
  {
    text: 'Configuracion',
    icon: 'folder',
    items: [
      {
        text: 'Categorias',
        path: '/categoria'
      },
      {
        text: 'Tipos',
        path: '/tipo'
      },
      {
        text: 'Clientes',
        path: '/clientes'
      }
    ]
  }
];
