import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;
import java.util.Random;

public class Final extends JPanel implements ActionListener, KeyListener, MouseMotionListener, MouseListener {
    private int playerX = 400, playerY = 300;
    private int mouseX = 400, mouseY = 300;
    private int playerSpeed = 7;
    private ArrayList<Enemy> enemies = new ArrayList<>();
    private Timer timer;
    private boolean gameOver = false;
    private boolean inGame = false;
    private int score = 0;
    private double spawnRate = 0.01;
    private int enemySpeed = 2;
    private boolean canClick = true;
    
    public Final() {
        setPreferredSize(new Dimension(800, 600));
        setBackground(Color.GREEN);
        setFocusable(true);
        addKeyListener(this);
        addMouseMotionListener(this);
        addMouseListener(this);
        timer = new Timer(16, this); // 60FPS
        timer.start();
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);

        if (!inGame) { //Title
            g.setColor(Color.WHITE);
            g.setFont(new Font("Arial", Font.BOLD, 67));
            g.drawString("Chase Game", 220, 300);
            g.setFont(new Font("Arial", Font.PLAIN, 35));
            g.drawString("Click to Start", 300, 350);
            return;
        }

        if (gameOver) {//game over
            g.setColor(Color.WHITE);
            g.setFont(new Font("Arial", Font.BOLD, 67));
            g.drawString("Game Over", 220, 300);
            g.setFont(new Font("Arial", Font.PLAIN, 36));
            g.drawString("Returning to Title...", 280, 350);
		  g.setFont(new Font("Arial", Font.BOLD,30));
		  g.drawString("Score:" + score,280,390);
            return;
        }

        //Player
        g.setColor(Color.BLUE);
        drawArrow(g, playerX, playerY, Math.atan2(mouseY - playerY, mouseX - playerX));

        //Enemy
        g.setColor(Color.RED);
        for (Enemy enemy : enemies) {
            g.fillOval(enemy.x - 15, enemy.y - 15, 30, 30);
        }

        //Score
        g.setColor(Color.WHITE);
        g.setFont(new Font("Arial", Font.PLAIN, 30));
        g.drawString("Score: " + score, 600, 580);
    }

    @Override
    public void actionPerformed(ActionEvent e) { //Gamesetting
        if (inGame && !gameOver) {
            moveEnemies();
            checkCollisions();
            spawnEnemies();
            increaseDifficulty();
        }
        repaint();
    }

    private void drawArrow(Graphics g, int x, int y, double angle) { //Arrowdrow
        Graphics2D g2d = (Graphics2D) g;
        g2d.translate(x, y);
        g2d.rotate(angle);
        g2d.fillPolygon(new int[]{-10, 10, -10}, new int[]{-15, 0, 15}, 3);
        g2d.rotate(-angle);
        g2d.translate(-x, -y);
    }

    private void moveEnemies() { //EnemyMove
        for (Enemy enemy : enemies) {
            double angle = Math.atan2(playerY - enemy.y, playerX - enemy.x);
            enemy.x += enemy.speed * Math.cos(angle);
            enemy.y += enemy.speed * Math.sin(angle);
        }
    }

    private void spawnEnemies() { //EnemySpown
        if (Math.random() < spawnRate) {
            Random rand = new Random();
            int x = rand.nextInt(800 + 100) - 50; //OutWindow
            int y = rand.nextInt(600 + 100) - 50;
            if (x >= 0 && x <= 800 && y >= 0 && y <= 600) {
                if (rand.nextBoolean()) x = rand.nextBoolean() ? -50 : 850;
                else y = rand.nextBoolean() ? -50 : 650;
            }
            enemies.add(new Enemy(x, y, enemySpeed));
        }
    }

	private void checkCollisions() { //Hitbox
    		for (int i = 0; i < enemies.size(); i++) {
        		Enemy enemy = enemies.get(i);
        		if (Math.hypot(playerX - enemy.x, playerY - enemy.y) < 30) {
            		gameOver = true;
            		inGame = true;
            		canClick = false;

            //BackTitle
            Timer restartTimer = new Timer(2000, evt -> {
                resetGame();
                canClick = true; //Clickrestart
            });
            restartTimer.setRepeats(false);
            restartTimer.start();

            return;
        }
    }
}

	private void resetGame() { //GameReset
    playerX = 400;
    playerY = 300;
    enemies.clear();
    score = 0;
    gameOver = false;
    inGame = false;
    spawnRate = 0.02;
    enemySpeed = 2;
    repaint();
}

    private void increaseDifficulty() { //EnemySpawnrise
        spawnRate += 0.0001;
        if (enemySpeed < 10) {
            enemySpeed += 0.001;
        }
    }

    @Override
    public void keyPressed(KeyEvent e) { //PlayerMove
        if (!inGame || gameOver) return;

        int key = e.getKeyCode();
        if (key == KeyEvent.VK_W) playerY -= playerSpeed; //w
        if (key == KeyEvent.VK_S) playerY += playerSpeed; //s
        if (key == KeyEvent.VK_A) playerX -= playerSpeed; //a
        if (key == KeyEvent.VK_D) playerX += playerSpeed; //d
    }

    @Override
    public void keyReleased(KeyEvent e) {} 

    @Override
    public void keyTyped(KeyEvent e) {}

    @Override
    public void mouseMoved(MouseEvent e) {
        mouseX = e.getX();
        mouseY = e.getY();
    }

    @Override
    public void mouseDragged(MouseEvent e) {}

    @Override
    public void mouseClicked(MouseEvent e) {
        if (!canClick) return;

        if (!inGame) {
            inGame = true;
            return;
        }

        if (gameOver) {
            resetGame();
            return;
        }

        if (SwingUtilities.isLeftMouseButton(e)) {
            performAttack();
        }
    }

    private void performAttack() { //PlayerAttack
        double angle = Math.atan2(mouseY - playerY, mouseX - playerX); 
        for (int i = 0; i < enemies.size(); i++) {
            Enemy enemy = enemies.get(i);
            double distance = Math.hypot(enemy.x - playerX, enemy.y - playerY);
            double enemyAngle = Math.atan2(enemy.y - playerY, enemy.x - playerX);
            double angleDifference = Math.abs(angle - enemyAngle);

            if (distance < 70 && angleDifference < Math.PI / 3) { //70pxAnd120angle
                enemies.remove(i);
                score += 100;
                i--;
            }
        }
    }

    @Override
    public void mouseEntered(MouseEvent e) {}

    @Override
    public void mouseExited(MouseEvent e) {}

    @Override
    public void mousePressed(MouseEvent e) {}

    @Override
    public void mouseReleased(MouseEvent e) {}

    public static void main(String[] args) {
        JFrame frame = new JFrame("Chase Game");
        Final game = new Final();
        frame.add(game);
        frame.pack();
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
    }

    class Enemy { //EnemyInfo
        int x, y, speed;

        public Enemy(int x, int y, int speed) {
            this.x = x;
            this.y = y;
            this.speed = speed;
        }
    }
}