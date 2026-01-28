/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./src/**/*.{html,js}'],
    theme: {
        extend: {
        colors: {
            amplify: {
            dark: '#0E0E10',      // Deep Void (Main Background)
            surface: '#18181B',   // Surface Layer (Cards/Sidebars)
            border: '#27272A',    // Subtle Borders
            primary: '#3B82F6',   // Electric Blue (Gradient Start)
            secondary: '#8B5CF6', // Vivid Violet (Gradient End)
            }
        },
        fontFamily: {
            sans: ['Montserrat', 'sans-serif'], // Or Montserrat
        }
        }
    }
}
