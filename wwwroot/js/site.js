window.onload = function() {
  // Get the body element by its unique id
  const bodyElement = document.getElementById(document.body.id);

  // If the body element exists, apply the active class to fade in
  if (bodyElement) {
      bodyElement.classList.add('active');
  }
};

window.onbeforeunload = function() {
  // Get the body element by its unique id
  const bodyElement = document.getElementById(document.body.id);

  // If the body element exists, remove the active class to fade out
  if (bodyElement) {
      bodyElement.classList.remove('active');
  }
};




document.addEventListener('DOMContentLoaded', function () {
  const menuToggle = document.querySelector('.menu-toggle');
  const navMenu = document.querySelector('.nav-menu');

  // Mobile menu toggle
  if (menuToggle && navMenu) {
    menuToggle.addEventListener('click', function () {
      menuToggle.classList.toggle('active');
      navMenu.classList.toggle('active');
    });
  }

  // Initially show the first set of projects and activate the first button
  const firstButton = document.querySelector('.project-buttons button');
  if (firstButton) {
    showProjects(1, firstButton);
  }
});

// Eye movement logic
const eyes = document.querySelectorAll('.eye');
const pupils = document.querySelectorAll('.pupil');

document.addEventListener('mousemove', (event) => {
  eyes.forEach((eye, index) => {
    const eyeRect = eye.getBoundingClientRect();
    const eyeCenterX = eyeRect.left + eyeRect.width / 2;
    const eyeCenterY = eyeRect.top + eyeRect.height / 2;

    const angle = Math.atan2(event.clientY - eyeCenterY, event.clientX - eyeCenterX);
    const maxDistance = 30;
    const pupilX = Math.cos(angle) * maxDistance;
    const pupilY = Math.sin(angle) * maxDistance;

    pupils[index].style.transform = `translate(${pupilX}px, ${pupilY}px)`;
  });
});

//Login/signup
document.addEventListener('DOMContentLoaded', function () {
  var signupModal = document.getElementById("signupModal");
  var loginModal = document.getElementById("loginModal");
  var signupButton = document.getElementById("signupButton");
  var loginButton = document.getElementById("loginButton");
  var closeSignup = document.getElementById("closeSignup");
  var closeLogin = document.getElementById("closeLogin");

  // Open Signup Modal
  signupButton.onclick = function () {
      signupModal.style.display = "block";
  }

  // Open Login Modal
  loginButton.onclick = function () {
      loginModal.style.display = "block";
  }

  // Close Signup Modal
  closeSignup.onclick = function () {
      signupModal.style.display = "none";
  }

  // Close Login Modal
  closeLogin.onclick = function () {
      loginModal.style.display = "none";
  }

  // Close modals when clicking outside of the modal
  window.onclick = function (event) {
      if (event.target === signupModal) {
          signupModal.style.display = "none";
      }
      if (event.target === loginModal) {
          loginModal.style.display = "none";
      }
  }
});





// Projects

function filterProjects(category, button) {
  // Get all buttons and remove the 'active' class from them
  const buttons = document.querySelectorAll('.project-buttons button');
  buttons.forEach(btn => btn.classList.remove('active'));

  // Add 'active' class to the clicked button
  button.classList.add('active');

  // Logic to filter projects based on the category (already implemented)
  const projectItems = document.querySelectorAll('.project-item');

  projectItems.forEach(item => {
    const itemCategory = item.getAttribute('data-category');
    if (category === 'all' || itemCategory === category) {
      item.classList.remove('hidden');
    } else {
      item.classList.add('hidden');
    }
  });
}




function openProject(projectId) {
  const slideWindow = document.getElementById('project-slide-window');
  const projectDetails = document.getElementById('project-details');
  const blurOverlay = document.getElementById('blur-overlay');

  // Add unique content dynamically based on projectId
  let content = '';
switch (projectId) {
  case 1:
    content = `
      <div class="project-container">
        <h2 class="project-title">My Personal Website</h2>
        <img src="/img/project1.jpg" alt="Project 1" class="project-image">
        <h3 class="project-subtitle">About</h3>
        <p class="project-description">My personal website that showcases all of my projects using .net framework.</p>
        <h4 class="project-technologies-title">Technologies</h4>
        <p2 class="project-technologies">
          <span class="tech-badge">ASP.Net</span>
          <span class="tech-badge">CSS</span>
          <span class="tech-badge">JS</span>
          <span class="tech-badge">Razor Page</span>
        </p2>
        <h5 class="project-website-title">Website</h5>
        <p>
          <a href="https://chayanonr.azurewebsites.net/" target="_blank" class="project-link">Learn More</a>
        </p>
      </div>
    `;
    break;
  case 2:
    content = `
      <div class="project-container">
        <h2 class="project-title">My Back Test Tools</h2>
        <img src="/img/project_spot.jpg" alt="Project 2" class="project-image">
        <h3 class="project-subtitle">About</h3>
        <p class="project-description">I implement back test script by using EMA 12 26 to help test the result.</p>
        <h4 class="project-technologies-title">Technologies</h4>
        <p2 class="project-technologies">
          <span class="tech-badge">Python</span>
          <span class="tech-badge">Investment</span>
           <span class="tech-badge">Binance API</span>
        </p2>
        <h5 class="project-website-title">Website</h5>
        <p>
          <a href="https://github.com/chayanonr/backtest" target="_blank" class="project-link">Learn More</a>
        </p>
      </div>
    `;
    break;
  case 3:
    content = `
      <div class="project-container">
        <h2 class="project-title">My Trading Bot</h2>
        <img src="/img/project_future.jpg" alt="Project 3" class="project-image">
        <h3 class="project-subtitle">About</h3>
        <p class="project-description">My project is focus on using script to operate in spot market in binance exchange. Focus on cross over of EMA 12 26 value.</p>
        <h4 class="project-technologies-title">Technologies</h4>
        <p2 class="project-technologies">
          <span class="tech-badge">Python</span>
          <span class="tech-badge">Binanace API</span>
          <span class="tech-badge">Investment</span>
        </p2>
        <h5 class="project-website-title">Website</h5>
        <p>
          <a href="https://github.com/chayanonr/EMA_Trading_BOT" target="_blank" class="project-link">Learn More</a>
        </p>
      </div>
    `;
    break;
  default:
    content = `<h2>Project not found</h2>`;
    break;
}


  // Inject the content into the slide window
  projectDetails.innerHTML = content;

  // Show the sliding window and blur overlay
  slideWindow.classList.add('active');
  blurOverlay.classList.add('active');

  // Add event listener for clicking outside the slide window (on the blur overlay)
  blurOverlay.addEventListener('click', closeProject);
}

function closeProject() {
  const slideWindow = document.getElementById('project-slide-window');
  const blurOverlay = document.getElementById('blur-overlay');

  // Hide the sliding window and blur overlay
  slideWindow.classList.remove('active');
  blurOverlay.classList.remove('active');

  // Remove the event listener for clicking outside the slide window
  blurOverlay.removeEventListener('click', closeProject);
}

// JavaScript to handle theme toggle
const toggleButton = document.getElementById('theme-toggle');
const currentTheme = localStorage.getItem('theme') || 'dark'; // Default to dark if no preference

// Set the current theme on page load
document.documentElement.setAttribute('data-theme', currentTheme);


toggleButton.addEventListener('click', () => {
  const theme = document.documentElement.getAttribute('data-theme');

  if (theme === 'dark') {
    document.documentElement.setAttribute('data-theme', 'light');
    localStorage.setItem('theme', 'light');
    
  } else {
    document.documentElement.setAttribute('data-theme', 'dark');
    localStorage.setItem('theme', 'dark');
    
  }
});

//Contact

document.addEventListener("DOMContentLoaded", function () {
  var contactForm = document.getElementById("contactForm");
  contactForm.onsubmit = function (event) {
      event.preventDefault(); // Prevent the default form submission

      // Get the message from the hidden input
      var message = document.getElementById("alert-message").value;
      if (message) {
          alert(message); // Show alert if message exists
      }

      // Optionally, submit the form programmatically
      // contactForm.submit(); // Uncomment this line if you want to submit after alert
  };
});

